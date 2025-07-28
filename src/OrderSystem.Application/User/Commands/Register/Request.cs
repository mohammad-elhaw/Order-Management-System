using MediatR;

namespace OrderSystem.Application.User.Commands.Register;
public record Request : IRequest<Response>
{
    public string FullName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
