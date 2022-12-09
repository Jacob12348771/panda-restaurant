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
    public class DeleteModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public DeleteModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }
            var table = await _context.Table.FindAsync(id);

            if (table != null)
            {
                Table = table;
                _context.Table.Remove(Table);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
