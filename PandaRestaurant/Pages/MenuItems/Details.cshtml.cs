using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.MenuItems
{
    public class DetailsModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public DetailsModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public MenuItem MenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MenuItem == null)
            {
                return NotFound();
            }

            var menuitem = await _context.MenuItem.FirstOrDefaultAsync(m => m.MenuItemID == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            else 
            {
                MenuItem = menuitem;
            }
            return Page();
        }
    }
}
