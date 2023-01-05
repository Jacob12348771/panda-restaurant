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
    public class DetailsModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public DetailsModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Order == null)
            {
                return NotFound();
            }

            var order = await _context.Order.
                Include(m => m.MenuItem)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            else 
            {
                Order = order;
            }
            return Page();
        }
    }
}
