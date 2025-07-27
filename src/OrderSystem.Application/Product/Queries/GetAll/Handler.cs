using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Product.Queries.GetAll;
public class Handler(
    OrderSystem.Queries.Product.GetAll.IRepository getAllRepo) 
    : IRequestHandler<Request, List<Response>>
{
    public async Task<List<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var products = await getAllRepo.GetAll();

        if(products == null || products.Count == 0)
            throw new HandledException("No products found.");

        return products.Select(p => new Response
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        }).ToList();

    }
}
