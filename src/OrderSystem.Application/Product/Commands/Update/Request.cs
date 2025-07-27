using MediatR;

namespace OrderSystem.Application.Product.Commands.Update;
public record Request : IRequest<Response>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
