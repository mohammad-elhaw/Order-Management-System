using MediatR;

namespace OrderSystem.Application.User.Commands.Login;
public record Request : IRequest<Response>
{
    public string Email { get; init; } = null!;
    public string Password { get; init; } = null!;
}
