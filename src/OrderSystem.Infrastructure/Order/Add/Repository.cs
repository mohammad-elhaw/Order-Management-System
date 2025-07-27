namespace OrderSystem.Infrastructure.Order.Add;
public class Repository(AppDbContext context) : IRepository
{
    public void Add(Domain.Entities.Order order) =>
        context.Orders.Add(order);

    public async Task<int> SaveChanges() =>
        await context.SaveChangesAsync();
}
