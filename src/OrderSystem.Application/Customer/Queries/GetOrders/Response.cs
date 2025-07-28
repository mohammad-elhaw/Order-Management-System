namespace OrderSystem.Application.Customer.Queries.GetOrders;
public record Response
{
    public Guid OrderId { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal TotalAmount { get; init; }
    public string Status { get; init; } = null!;
}
