using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;
using System.Drawing;

namespace PandaRestaurant.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string OrderNumberSort { get; set; }
        public string OrderDateSort { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Order> Order { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            CurrentSort = sortOrder;
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
            var pageSize = Configuration.GetValue("PageSize", 5);
                Order = await PaginatedList<Order>.CreateAsync(
                ordersIQ
                .Include(o => o.Customer)
                .Include(o => o.Table)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }

    }
}
