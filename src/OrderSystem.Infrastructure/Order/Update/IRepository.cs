namespace OrderSystem.Infrastructure.Order.Update;
public interface IRepository
{
    void Update(Domain.Entities.Order order);
    Task<int> SaveChanges();
}
