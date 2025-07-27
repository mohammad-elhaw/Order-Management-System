using MediatR;
using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Application.Order.Commands.Add;
public class Handler(
    Infrastructure.Order.Add.IRepository addRepo) 
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

        var order = new Domain.Entities.Order
        {
            CustomerId = request.CustomerId,
            OrderDate = DateTime.UtcNow,
            PaymentMethod = request.PaymentMethod,
            Status = Domain.Enums.OrderStatus.Pending,
            OrderItems = request.OrderItems.Select(item => new Domain.Entities.OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            }).ToList()
        };
        order.TotalAmount = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
        addRepo.Add(order);

        int saveResult = await addRepo.SaveChanges();
        if(saveResult <= 0)
            throw new UnHandledException("Failed to add order");

        // If the order was added successfully, return the response

        return new Response
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            PaymentMethod = order.PaymentMethod,
            Status = order.Status,
            OrderItems = order.OrderItems.Select(oi => new OrderItemResponse
            {
                Id = oi.Id,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToList()
        };
    }
}
