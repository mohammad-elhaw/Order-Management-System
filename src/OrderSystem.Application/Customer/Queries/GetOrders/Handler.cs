using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Customer.Queries.GetOrders;
public class Handler(
    OrderSystem.Queries.Customer.GetAllOrders.IRepository getOrdersRepo,
    OrderSystem.Queries.Customer.Exists.IRespository customerExistsRepo) 
    : IRequestHandler<Query, List<Response>>
{
    public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
    {

        if (!(await customerExistsRepo.Exists(request.CustomerId)))
        {
            throw new HandledException("Customer does not exist");
        }
        var orders = await getOrdersRepo.GetAllOrders(request.CustomerId);
        return orders.Select(o =>
            new Response
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status.ToString()
            }).ToList();
    }
}
