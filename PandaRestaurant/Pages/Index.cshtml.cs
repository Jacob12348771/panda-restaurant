using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Models;

namespace PandaRestaurant.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PandaRestaurant.Data.ApplicationDbContext _context;

        public IndexModel(PandaRestaurant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;
        public IList<Table> Table { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Order != null)
            {
                Order = await _context.Order
                .Include(o => o.MenuItem)
                .Include(o => o.Table).ToListAsync();
            }

            if (_context.Table != null)
            {
                Table = await _context.Table.ToListAsync();
            }
        }
    }
}