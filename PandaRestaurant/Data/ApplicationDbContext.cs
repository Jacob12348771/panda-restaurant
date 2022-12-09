using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PandaRestaurant.Models;

namespace PandaRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PandaRestaurant.Models.Customer> Customer { get; set; }
        public DbSet<PandaRestaurant.Models.Employee> Employee { get; set; }
        public DbSet<PandaRestaurant.Models.Table> Table { get; set; }
    }
}