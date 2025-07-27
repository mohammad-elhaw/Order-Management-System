namespace OrderSystem.Infrastructure.Product.Update;
public class Repository(AppDbContext context) : IRepository
{
    public void Update(Domain.Entities.Product product) =>
        context.Products.Update(product);

    public async Task<int> SaveChanges() =>
        await context.SaveChangesAsync();
}
