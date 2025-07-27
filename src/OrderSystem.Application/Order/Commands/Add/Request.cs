using MediatR;
using OrderSystem.Domain.Enums;

namespace OrderSystem.Application.Order.Commands.Add;
public record Request(
    Guid CustomerId,
    List<OrderItemsRecord> OrderItems,
    PaymentMethod PaymentMethod) : IRequest<Response>;


public record OrderItemsRecord(
    Guid ProductId,
    int Quantity,
    decimal UnitPrice);