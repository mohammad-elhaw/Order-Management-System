using MediatR;

namespace OrderSystem.Application.Customer.Queries.GetOrders;
public record Query(Guid CustomerId) : IRequest<List<Response>>;
