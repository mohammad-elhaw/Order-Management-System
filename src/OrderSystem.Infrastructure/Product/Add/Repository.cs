
namespace OrderSystem.Infrastructure.Product.Add;
public class Repository(AppDbContext context) : IRepository
{
    public void AddProduct(Domain.Entities.Product product) =>
        context.Products.Add(product);

    public async Task<int> SaveChanges() =>
        await context.SaveChangesAsync();
}
