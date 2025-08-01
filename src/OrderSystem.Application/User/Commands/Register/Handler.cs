using MediatR;
using Microsoft.AspNetCore.Identity;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.User.Commands.Register;
public class Handler(
    UserManager<Domain.Entities.User> userManager) : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            UserName = request.UserName,
            Email = request.Email,
            FullName = request.FullName,
        };

        var identityResult = await userManager.CreateAsync(user, request.Password);
        if (!identityResult.Succeeded)
            throw new HandledException("User registration failed");

        await userManager.AddToRoleAsync(user, "Customer");

        return new Response
        {
            Email = user.Email,
            FullName = user.FullName,
            UserName = user.UserName
        };
    }
}
