using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public IndexModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string OrderSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            OrderSort = sortOrder == "Orders" ? "Orders_desc" : "Orders";

            CurrentFilter = searchString;

            IQueryable<Customer> customersIQ = from c in _context.Customer
                                               select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                customersIQ = customersIQ.Where(c => c.CustomerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    customersIQ = customersIQ.OrderByDescending(c => c.CustomerName);
                    break;
                case "Orders":
                    customersIQ = customersIQ.OrderBy(c => c.Orders.Count);
                    break;
                case "Orders_desc":
                    customersIQ = customersIQ.OrderByDescending(c => c.Orders.Count);
                    break;
                default:
                    customersIQ = customersIQ.OrderBy(c => c.CustomerName);
                    break;
            }

            Customer = await customersIQ
                .Include(o => o.Orders)
                .ToListAsync();
        }
    }
}
