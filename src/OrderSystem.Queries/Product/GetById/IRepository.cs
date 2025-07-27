namespace OrderSystem.Queries.Product.GetById;
public interface IRepository
{
    Task<Domain.Entities.Product?> Get(Guid id);
}
