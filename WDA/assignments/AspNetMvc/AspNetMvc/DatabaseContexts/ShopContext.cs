using AspNetMvc.Configurations;
using AspNetMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.DatabaseContexts;

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
