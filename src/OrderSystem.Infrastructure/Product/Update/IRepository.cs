namespace OrderSystem.Infrastructure.Product.Update;
public interface IRepository
{
    void Update(Domain.Entities.Product product);
    Task<int> SaveChanges();
}
