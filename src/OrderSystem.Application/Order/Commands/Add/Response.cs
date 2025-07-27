using OrderSystem.Domain.Enums;

namespace OrderSystem.Application.Order.Commands.Add;
public record Response
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public DateTime OrderDate { get; init; }
    public decimal TotalAmount { get; init; }
    public PaymentMethod PaymentMethod { get; init; }
    public OrderStatus Status { get; init; }
    public List<OrderItemResponse> OrderItems { get; init; } = new();
    
}

public record OrderItemResponse
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}