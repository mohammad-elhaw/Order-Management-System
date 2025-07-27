namespace OrderSystem.Queries.Order.GetAll;
public interface IRepository
{
    Task<List<Domain.Entities.Order>> GetAll();
}
