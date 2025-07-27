namespace OrderSystem.Application.Product.Queries.GetById;
public record Response
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
