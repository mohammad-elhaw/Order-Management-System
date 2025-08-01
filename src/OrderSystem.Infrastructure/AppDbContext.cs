using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderSystem.Domain.Entities;

namespace OrderSystem.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) 
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Domain.Entities.Customer> Customers { get; set; }
    public DbSet<Domain.Entities.Order> Orders { get; set; }
    public DbSet<Domain.Entities.OrderItem> OrderItems { get; set; }
    public DbSet<Domain.Entities.Product> Products { get; set; }
    public DbSet<Domain.Entities.Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(builder.GetType().Assembly);
    }

}
