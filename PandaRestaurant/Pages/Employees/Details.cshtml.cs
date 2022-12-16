using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Data;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public DetailsModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
