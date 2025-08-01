using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderSystem.Application.TokenService;
public class TokenService
    (IConfiguration config,
    UserManager<Domain.Entities.User> userManager) : ITokenService
{
    public async Task<string> GenerateAccessTokenAsync(Domain.Entities.User user)
    {
        var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
            };

        var roles = await userManager.GetRolesAsync(user);
        authClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: authClaims,
            expires: DateTime.Now.AddMinutes(int.Parse(config["Jwt:AccessTokenExpirationMinutes"]!)),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateRefreshTokenAsync(IdentityUser<Guid> user)
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
    }

}
