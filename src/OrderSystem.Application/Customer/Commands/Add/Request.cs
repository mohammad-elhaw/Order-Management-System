using MediatR;

namespace OrderSystem.Application.Customer.Commands.Add;
public record Request : IRequest<Response>
{
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;
}
