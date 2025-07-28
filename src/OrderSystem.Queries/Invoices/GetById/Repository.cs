using Dapper;
using OrderSystem.Domain.Entities;
using System.Data;

namespace OrderSystem.Queries.Invoices.GetById;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<Invoice?> GetById(Guid id)
    {
        const string sql = @"
            SELECT
                i.Id, i.OrderId, i.TotalAmount, i.InvoiceDate,
                o.Id, o.CustomerId, o.OrderDate, o.TotalAmount
            FROM Invoices i
            INNER JOIN Orders o ON i.OrderId = o.Id
            WHERE i.Id = @InvoiceId";

        var invoice = await connection.QueryAsync<Domain.Entities.Invoice,
            Domain.Entities.Order, Domain.Entities.Invoice>(
            sql,
            (invoice, order) =>
            {
                invoice.Order = order;
                return invoice;
            },
            param: new { InvoiceId = id },
            splitOn: "Id");

        return invoice.FirstOrDefault();
    }
}
