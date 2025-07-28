using Microsoft.AspNetCore.Identity;

namespace OrderSystem.Domain.Entities;
public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = null!;
}
