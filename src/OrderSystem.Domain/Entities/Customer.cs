using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Domain.Entities;
public class Customer : BaseEntity
{
    [Length(5, 50)]
    public string Name { get; set; } = null!;
    [EmailAddress]
    [Length(10, 100)]
    public string Email { get; set; } = null!;

    public Guid? UserId { get; set; }
    public User? User { get; set; }
    public List<Order> Orders { get; set; } = [];
}
