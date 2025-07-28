namespace OrderSystem.Queries.Customer.Exists;
public interface IRespository
{
    Task<bool> Exists(Guid customerId);
}
