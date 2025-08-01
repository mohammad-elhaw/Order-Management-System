using Microsoft.AspNetCore.Identity;

namespace OrderSystem.Application.TokenService;
public interface ITokenService
{
    Task<string> GenerateAccessTokenAsync(Domain.Entities.User user);
    string GenerateRefreshTokenAsync(IdentityUser<Guid> user);
}
