using Dapper;
using System.Data.Common;

namespace OrderSystem.Queries.Order.GetById;
public class Repository(DbConnection connection) : IRepository
{
    public async Task<Domain.Entities.Order?> Get(Guid id)
    {
        const string sql = @"SELECT * FROM Orders WHERE Id = @id";
        var order = await connection.QuerySingleOrDefaultAsync<Domain.Entities.Order>(sql, new { id });
        return order;
    }
}
