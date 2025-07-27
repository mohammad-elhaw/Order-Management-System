using MediatR;

namespace OrderSystem.Application.Product.Queries.GetById;
public record Request : IRequest<Response>
{
    public Guid Id { get; init; }
}
