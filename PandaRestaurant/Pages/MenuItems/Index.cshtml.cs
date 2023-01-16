using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.MenuItems
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration Configuration;
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public IndexModel(PandaRestaurant.Data.ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string MenuItemNumberSort { get; set; }
        public string MenuItemNameSort { get; set; }

        public string MenuItemPrepTimeSort { get; set; }
        public string MenuItemPriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<MenuItem> MenuItem { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            CurrentSort = sortOrder;
            MenuItemNumberSort = String.IsNullOrEmpty(sortOrder) ? "MenuItemID_desc" : "";
            MenuItemNameSort = sortOrder == "MenuItemName" ? "MenuItemName_desc" : "MenuItemName";
            MenuItemPrepTimeSort = sortOrder == "MenuItemPrepTime" ? "MenuItemPrepTime_desc" : "MenuItemPrepTime";
            MenuItemPriceSort = sortOrder == "MenuItemPrice" ? "MenuItemPrice_desc" : "MenuItemPrice";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            currentFilter = searchString;

            IQueryable<MenuItem> menuItemsIQ = from m in _context.MenuItem
                                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                menuItemsIQ = menuItemsIQ.Where(m => m.MenuItemName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "MenuItemID_desc":
                    menuItemsIQ = menuItemsIQ.OrderByDescending(m => m.MenuItemID);
                    break;
                case "MenuItemName":
                    menuItemsIQ = menuItemsIQ.OrderBy(m => m.MenuItemName);
                    break;
                case "MenuItemName_desc":
                    menuItemsIQ = menuItemsIQ.OrderByDescending(m => m.MenuItemName);
                    break;
                case "MenuItemPrepTime_desc":
                    menuItemsIQ = menuItemsIQ.OrderByDescending(m => m.MenuItemPrepTime);
                    break;
                case "MenuItemPrepTime":
                    menuItemsIQ = menuItemsIQ.OrderBy(m => m.MenuItemPrepTime);
                    break;
                case "MenuItemPrice_desc":
                    menuItemsIQ = menuItemsIQ.OrderByDescending(m => m.MenuItemPrice);
                    break;
                case "MenuItemPrice":
                    menuItemsIQ = menuItemsIQ.OrderBy(m => m.MenuItemPrice);
                    break;
                default:
                    menuItemsIQ = menuItemsIQ.OrderBy(m => m.MenuItemID);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 5);
            MenuItem = await PaginatedList<MenuItem>.CreateAsync(
            menuItemsIQ
            .AsNoTracking(), pageIndex ?? 1, pageSize);

        }

    }

}


