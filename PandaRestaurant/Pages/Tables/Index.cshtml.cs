using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Tables
{
    public class IndexModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public IndexModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string TableNumberSort { get; set; }
        public string OccupiedSort { get; set; }

        public IList<Table> Table { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
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

                Table = await tablesIQ
                    .Include(o => o.Orders)
                    .Include(o => o.Employees)
                    .ToListAsync();
        }
    }
}
