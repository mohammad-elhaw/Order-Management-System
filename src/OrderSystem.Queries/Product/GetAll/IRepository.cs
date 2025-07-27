namespace OrderSystem.Queries.Product.GetAll;
public interface IRepository
{
    Task<List<Domain.Entities.Product>> GetAll();
}
