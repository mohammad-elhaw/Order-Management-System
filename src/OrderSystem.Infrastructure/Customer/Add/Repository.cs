namespace OrderSystem.Infrastructure.Customer.Add;
public class Repository(AppDbContext context) : IRepository
{
    public void Add(Domain.Entities.Customer customer) =>
        context.Customers.Add(customer);

    public async Task<int> SaveChanges() => 
        await context.SaveChangesAsync();
}
