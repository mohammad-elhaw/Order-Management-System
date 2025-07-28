using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Invoices.Queries.GetById;
public class Handler (
    OrderSystem.Queries.Invoices.GetById.IRepository getRepo)
    : IRequestHandler<Query, Response>
{
    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var invoice = await getRepo.GetById(request.Id);
        if (invoice == null)
            throw new HandledException($"Invoice with ID {request.Id} not found.");
        
        return new Response
        {
            Id = invoice.Id,
            IssuedDate = invoice.InvoiceDate,
            TotalAmount = invoice.TotalAmount,
            Order = new OrderResponse
            {
                Id = invoice.Order.Id,
                OrderDate = invoice.Order.OrderDate,
                TotalAmount = invoice.Order.TotalAmount,
            }
        };
    }
}
