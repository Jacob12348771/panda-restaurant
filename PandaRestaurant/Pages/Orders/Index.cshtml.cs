using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public IndexModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string OrderNumberSort { get; set; }
        public string OrderDateSort { get; set; }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            OrderNumberSort = String.IsNullOrEmpty(sortOrder) ? "OrderID_desc" : "";
            OrderDateSort = sortOrder == "OrderDateTime" ? "OrderDateTime_desc" : "OrderDateTime";

            IQueryable<Order> ordersIQ = from o in _context.Order
                                         select o;

            switch(sortOrder)
            {
                case "OrderID_desc":
                    ordersIQ = ordersIQ.OrderByDescending(o => o.OrderID);
                    break;
                case "OrderDateTime":
                    ordersIQ = ordersIQ.OrderBy(o => o.OrderDatetime).Take(10);
                    break;
                case "OrderDateTime_desc":
                    ordersIQ = ordersIQ.OrderByDescending(o => o.OrderDatetime).Take(10);
                    break;
                default:
                    ordersIQ = ordersIQ.OrderBy(o => o.OrderID);
                    break;
            }
                Order = await ordersIQ
                .Include(o => o.Customer)
                .Include(o => o.Table)
                .ToListAsync();
        }
    }
}
