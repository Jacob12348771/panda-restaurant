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
        // Entity sets created.
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        
        // References to other entities delclared. Allows pages to related data.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer")
                .HasMany(o => o.Orders)
                .WithOne(c => c.Customer);
            modelBuilder.Entity<Employee>().ToTable("Employee")
                .HasMany(t => t.Tables)
                .WithMany(e => e.Employees);
            modelBuilder.Entity<Table>().ToTable("Table");
            modelBuilder.Entity<Order>().ToTable("Order")
                .HasMany(m => m.MenuItem)
                .WithMany(o => o.Orders);
            modelBuilder.Entity<MenuItem>().ToTable("MenuItem");
            base.OnModelCreating(modelBuilder);
        }
    }
}