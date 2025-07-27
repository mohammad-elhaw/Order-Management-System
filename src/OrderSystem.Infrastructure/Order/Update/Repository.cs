namespace OrderSystem.Infrastructure.Order.Update;
public class Repository(AppDbContext context) : IRepository
{
    public async Task<int> SaveChanges() =>
        await context.SaveChangesAsync();
    

    public void Update(Domain.Entities.Order order) =>
        context.Orders.Update(order);
}
