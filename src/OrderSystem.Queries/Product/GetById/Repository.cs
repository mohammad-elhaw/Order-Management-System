using Dapper;
using System.Data;

namespace OrderSystem.Queries.Product.GetById;
public class Repository(IDbConnection connection) : IRepository
{
    public Task<Domain.Entities.Product?> Get(Guid id)
    {
        var query = "SELECT * FROM Products WHERE Id = @id";
        return connection.QueryFirstOrDefaultAsync<Domain.Entities.Product?>(query, new { id });
    }
}
