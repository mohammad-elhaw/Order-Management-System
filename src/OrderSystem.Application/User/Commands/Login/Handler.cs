using MediatR;
using Microsoft.AspNetCore.Identity;
using OrderSystem.Application.TokenService;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.User.Commands.Login;
public class Handler(
    UserManager<Domain.Entities.User> userManager,
    SignInManager<Domain.Entities.User> signInManager,
    ITokenService tokenService) : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null)
            throw new HandledException("Invalid email or password");
    
        var result = await signInManager
            .PasswordSignInAsync(user, request.Password, false, false);

        if (!result.Succeeded)
            throw new HandledException("Invalid email or password");

        var token = await tokenService.GenerateAccessTokenAsync(user);
        var refreshToken = tokenService.GenerateRefreshTokenAsync(user);

        return new Response
        {
            Email = user.Email!,
            FullName = user.FullName,
            AccessToken = token,
            RefreshToken = refreshToken
        };
    }
}
