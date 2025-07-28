using MediatR;

namespace OrderSystem.Application.Customer.Queries.GetCustomers;
public class Handler(
    OrderSystem.Queries.Customer.GetAllCustomers.IRepository getAllRepo) 
    : IRequestHandler<Query, List<Response>>
{
    public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
    {

        var customers = await getAllRepo.GetAll();
        var response = customers.Select(c => 
            new Response
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Orders = c.Orders.Select(o => new CustomerOrdersRecord
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString()
                }).ToList()
            }).ToList();

        return response;
    }
}
