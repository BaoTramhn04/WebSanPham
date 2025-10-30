using Microsoft.EntityFrameworkCore;
using WebProductManagement.Models;

namespace WebProductManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);
    modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "Iphone 15", Price = 25000 },
        new Product { Id = 2, Name = "Samsung S24", Price = 22000 }
    );
}

    }
}
