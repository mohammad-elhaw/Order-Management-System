namespace OrderSystem.API.Product.Product.Commands.Add;
public record Response(
    Guid Id,
    string Name,
    decimal Price,
    int Stock);
