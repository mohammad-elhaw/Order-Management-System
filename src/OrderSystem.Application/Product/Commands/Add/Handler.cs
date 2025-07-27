using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.API.Product.Product.Commands.Add;
public class Handler(
    Infrastructure.Product.Add.IRepository addRepo) : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

        Domain.Entities.Product product = new Domain.Entities.Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            Stock = request.stock
        };

        addRepo.AddProduct(product);

        int result = await addRepo.SaveChanges();

        if (result <= 0)
            throw new HandledException("Failed to Save Product");

        return new Response(
            Id: product.Id,
            Name: product.Name,
            Price: product.Price,
            Stock: product.Stock);
    }
}
