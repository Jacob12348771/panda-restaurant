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
    public class DetailsModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public DetailsModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Table Table { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FirstOrDefaultAsync(m => m.TableID == id);
            if (table == null)
            {
                return NotFound();
            }
            else 
            {
                Table = table;
            }
            return Page();
        }
    }
}
