namespace OrderSystem.Infrastructure.Order.Add;
public interface IRepository
{
    void Add(Domain.Entities.Order order);
    Task<int> SaveChanges();
}
