using MediatR;

namespace OrderSystem.API.Product.Product.Commands.Add;
public record Request(
    string Name,
    decimal Price,
    int stock) : IRequest<Response>;