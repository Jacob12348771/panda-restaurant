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
        public DbSet<PandaRestaurant.Models.Order> Order { get; set; }
        public DbSet<PandaRestaurant.Models.MenuItem> MenuItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
            base.OnModelCreating(modelBuilder);
        }
    }
}