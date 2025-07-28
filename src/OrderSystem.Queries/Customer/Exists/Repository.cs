using Dapper;
using System.Data;

namespace OrderSystem.Queries.Customer.Exists;
public class Repository(IDbConnection connection) : IRespository
{
    public Task<bool> Exists(Guid customerId)
    {
        var sql = "SELECT COUNT(1) FROM Customers WHERE Id = @CustomerId";
        return connection.ExecuteScalarAsync<bool>(sql, new { CustomerId = customerId });
    }
}
