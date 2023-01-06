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
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(PandaRestaurant.Data.ApplicationDbContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

      [BindProperty]
      public Table Table { get; set; }
      public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Table == null)
            {
                return NotFound();
            }

            Table = await _context.Table.FirstOrDefaultAsync(m => m.TableID == id);

            if (Table == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = string.Format("Deletion of {TableID} failed. Please try again", id);
            }
           
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await _context.Table.FindAsync(id);

            if (table == null)
            {
                return NotFound();
            }

            try
            {
                _context.Table.Remove(table);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            // Highlighting if deletion has failed at db level, causing error to be displayed.
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
