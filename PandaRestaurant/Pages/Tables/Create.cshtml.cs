using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Tables
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public CreateModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Table Table { get; set; }
        

        // Using Table object to prevent overposting.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTable = new Table();
            
            if (await TryUpdateModelAsync<Table>(
                emptyTable,
                "table",
                t => t.TableOccupied))
            {
                _context.Table.Add(Table);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
