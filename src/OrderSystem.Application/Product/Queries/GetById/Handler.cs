using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Product.Queries.GetById;
public class Handler(
    OrderSystem.Queries.Product.GetById.IRepository getRepo) : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var product = await getRepo.Get(request.Id);
        if(product == null)
            throw new HandledException($"Product with ID {request.Id} not found.");
        
        return new Response
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}
