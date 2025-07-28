namespace OrderSystem.Application.Customer.Commands.Add;
public record Response
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public string Email { get; init; } = null!;
}
