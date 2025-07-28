using MediatR;

namespace OrderSystem.Application.Invoices.Queries.GetAll;
public class Handler (
    OrderSystem.Queries.Invoices.GetAll.IRepository getAllRepo)
    : IRequestHandler<Query, List<Response>>
{
    public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
    {

        var invoices = await getAllRepo.GetAll();
        return invoices.Select(i => new Response
        {
            Id = i.Id,
            IssuedDate = i.InvoiceDate,
            TotalAmount = i.TotalAmount,
            Order = new OrderResponse
            {
                Id = i.Order.Id,
                CustomerId = i.Order.CustomerId,
                OrderDate = i.Order.OrderDate,
                TotalAmount = i.Order.TotalAmount
            }

        }).ToList();
    }
}
