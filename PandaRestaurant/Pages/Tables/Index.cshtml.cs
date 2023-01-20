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
using Microsoft.AspNetCore.Authorization;

namespace PandaRestaurant.Pages.Tables
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string TableNumberSort { get; set; }
        public string OccupiedSort { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Table> Table { get; set; }

        public async Task OnGetAsync(string sortOrder, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TableNumberSort = String.IsNullOrEmpty(sortOrder) ? "TableID_desc" : "";
            OccupiedSort = sortOrder == "TableOccupied" ? "TableOccupied_desc" : "TableOccupied";

            IQueryable<Table> tablesIQ = from s in _context.Table
                                             select s;

            switch (sortOrder)
            {
                case "TableID_desc":
                    tablesIQ = tablesIQ.OrderByDescending(t => t.TableID);
                    break;
                case "TableOccupied":
                    tablesIQ = tablesIQ.OrderBy(t => t.TableOccupied);
                    break;
                case "TableOccupied_desc":
                    tablesIQ = tablesIQ.OrderByDescending(t => t.TableOccupied);
                    break;
                default:
                    tablesIQ = tablesIQ.OrderBy(t => t.TableID);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 5);
                Table = await PaginatedList<Table>.CreateAsync(
                    tablesIQ
                    .Include(o => o.Orders)
                    .Include(o => o.Employees)
                    .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
