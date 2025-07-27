using System.ComponentModel.DataAnnotations;

namespace OrderSystem.Domain.Entities;
public class Product : BaseEntity
{
    [Length(5, 100)]
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

}
