using Dapper;
using System.Data;

namespace OrderSystem.Queries.Product.GetAll;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<List<Domain.Entities.Product>> GetAll()
    {
        const string sql = @"SELECT * FROM Products";

        var products =  (await connection.QueryAsync<Domain.Entities.Product>(sql)).ToList();

        return products;
    }
}
