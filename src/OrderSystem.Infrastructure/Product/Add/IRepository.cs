namespace OrderSystem.Infrastructure.Product.Add;
public interface IRepository
{
    void AddProduct(Domain.Entities.Product product);
    Task<int> SaveChanges();
}
