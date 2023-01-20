using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Tables
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public EditModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Table Table { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            // Small performance bonus - Find async used to as no related data is being returned.
            Table = await _context.Table.FindAsync(id);

            if (Table == null)
            {
                return NotFound();
            }
            return Page();
        }

        // Using Table object to prevent overposting.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var tableToUpdate = await _context.Table.FindAsync(id);

            if (tableToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                tableToUpdate,
                "table",
                t => t.TableOccupied))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
