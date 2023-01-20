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

namespace PandaRestaurant.Pages.Orders
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
        ViewData["CustomerID"] = new SelectList(_context.Customer, "CustomerID", "CustomerID");
        ViewData["TableID"] = new SelectList(_context.Table, "TableID", "TableID");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
