namespace OrderSystem.Infrastructure.Customer.Add;
public interface IRepository
{
    void Add(Domain.Entities.Customer customer);
    Task<int> SaveChanges();
}
