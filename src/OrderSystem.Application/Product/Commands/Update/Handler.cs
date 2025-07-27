using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Product.Commands.Update;
public class Handler (
    Infrastructure.Product.Update.IRepository updateRepo,
    OrderSystem.Queries.Product.GetById.IRepository getProductRepo)
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var product = await getProductRepo.Get(request.Id);
        if(product is null)
            throw new HandledException("Product not found");

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        updateRepo.Update(product);
        int saveResult = await updateRepo.SaveChanges();
        if (saveResult <= 0)
            throw new UnHandledException("Error occur when updating the product");

        return new Response
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }
}
