using Dapper;
using System.Data;

namespace OrderSystem.Queries.Customer.GetAllCustomers;
public class Repository(IDbConnection connection) : IRepository
{
    public async Task<List<Domain.Entities.Customer>> GetAll()
    {
        const string sql = @"
            SELECT 
                c.Id, c.Name, c.Email,
                o.Id, o.CustomerId, o.OrderDate, o.TotalAmount, o.PaymentMethod, o.Status
            FROM Customers c
            LEFT JOIN Orders o ON c.Id = o.CustomerId
            ORDER BY c.Id";

        var customerDic = new Dictionary<Guid, Domain.Entities.Customer>();

        var result = await connection.QueryAsync<Domain.Entities.Customer, Domain.Entities.Order,
            Domain.Entities.Customer>(sql,
            (customer, order) =>
            {
                if (!customerDic.TryGetValue(customer.Id, out var existingCutomer))
                {
                    existingCutomer = customer;
                    existingCutomer.Orders = [];
                    customerDic.Add(customer.Id, customer);
                }

                if (order != null && order.Id != Guid.Empty)
                {
                    existingCutomer.Orders.Add(order);
                }
                return existingCutomer;
            },
            splitOn: "Id");

        return customerDic.Values.ToList();

    }
}
