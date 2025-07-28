namespace OrderSystem.Queries.Customer.GetAllCustomers;
public interface IRepository
{
    Task<List<Domain.Entities.Customer>> GetAll();
}
