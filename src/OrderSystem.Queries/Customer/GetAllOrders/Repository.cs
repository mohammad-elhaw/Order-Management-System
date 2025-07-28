using Dapper;
using System.Data;

namespace OrderSystem.Queries.Customer.GetAllOrders;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<List<Domain.Entities.Order>> GetAllOrders(Guid customerId)
    {
        var sql = @"
            SELECT o.Id, o.OrderDate, o.TotalAmount, o.Status
            FROM Orders o
            WHERE o.CustomerId = @CustomerId";
        return (await connection.QueryAsync<Domain.Entities.Order>(sql, new { CustomerId = customerId })).ToList();
    }
}
