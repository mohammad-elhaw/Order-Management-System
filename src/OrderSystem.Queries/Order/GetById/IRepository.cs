namespace OrderSystem.Queries.Order.GetById;
public interface IRepository
{
    Task<Domain.Entities.Order?> Get(Guid id);
}
