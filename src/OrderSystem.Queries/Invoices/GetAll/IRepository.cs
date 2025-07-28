namespace OrderSystem.Queries.Invoices.GetAll;
public interface IRepository
{
    Task<List<Domain.Entities.Invoice>> GetAll();
}
