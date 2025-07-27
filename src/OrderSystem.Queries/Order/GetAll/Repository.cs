using Dapper;
using System.Data;

namespace OrderSystem.Queries.Order.GetAll;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<List<Domain.Entities.Order>> GetAll()
    {
        const string sql = @"SELECT * FROM Orders";
        return (await connection.QueryAsync<Domain.Entities.Order>(sql)).ToList();
    }
}
