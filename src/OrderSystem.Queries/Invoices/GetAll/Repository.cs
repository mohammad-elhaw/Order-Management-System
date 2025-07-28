using Dapper;
using OrderSystem.Domain.Entities;
using System.Data;

namespace OrderSystem.Queries.Invoices.GetAll;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<List<Invoice>> GetAll()
    {
        const string sql = @"
            SELECT
                i.Id, i.OrderId, i.TotalAmount, i.InvoiceDate,
                o.Id, o.CustomerId, o.OrderDate, o.TotalAmount
            FROM Invoices i
            INNER JOIN Orders o ON i.OrderId = o.Id";

        var invoiceDic = new Dictionary<Guid, Domain.Entities.Invoice>();

        var invoices = await connection.QueryAsync<Domain.Entities.Invoice,
            Domain.Entities.Order, Domain.Entities.Invoice>(
            sql,
            (invoice, order) =>
            {
                if (!invoiceDic.TryGetValue(invoice.Id, out var invoiceEntry))
                {
                    invoiceEntry = invoice;
                    invoiceEntry.Order = order;
                    invoiceDic.Add(invoiceEntry.Id, invoiceEntry);
                }
                return invoiceEntry;
            },
            splitOn: "Id");

        return invoices.ToList();

    }
}
