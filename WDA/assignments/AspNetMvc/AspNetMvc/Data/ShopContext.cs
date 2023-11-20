using AspNetMvc.Entities;
using AspNetMvc.Utilities;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.Data;

public class ShopContext : DbContext
{
    public ShopContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
