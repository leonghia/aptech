using Microsoft.EntityFrameworkCore;
using OrderAPI.Entities;

namespace OrderAPI.DatabaseContexts;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions options) : base(options)
    {
        
    }

    public required DbSet<Order> Orders { get; init; }
}
