using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Customers
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string OrderSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            OrderSort = sortOrder == "Orders" ? "Orders_desc" : "Orders";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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

            var pageSize = Configuration.GetValue("PageSize", 5);
                Customer = await PaginatedList<Customer>.CreateAsync(
                customersIQ
                .Include(o => o.Orders)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
