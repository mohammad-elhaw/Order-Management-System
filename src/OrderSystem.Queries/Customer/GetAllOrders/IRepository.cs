namespace OrderSystem.Queries.Customer.GetAllOrders;
public interface IRepository
{
    Task<List<Domain.Entities.Order>> GetAllOrders(Guid customerId);
}
