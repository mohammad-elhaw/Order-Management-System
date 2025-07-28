namespace OrderSystem.Queries.Invoices.GetById;
public interface IRepository
{
    Task<Domain.Entities.Invoice?> GetById(Guid id);
}
