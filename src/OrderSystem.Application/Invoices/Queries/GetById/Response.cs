namespace OrderSystem.Application.Invoices.Queries.GetById;
public record Response
{
    public Guid Id { get; init; }
    public decimal TotalAmount { get; init; }
    public DateTime IssuedDate { get; init; }
    public OrderResponse Order { get; init; } = null!;
}

public class OrderResponse
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal TotalAmount { get; init; }
}
