using MediatR;

namespace OrderSystem.Application.Customer.Queries.GetCustomers;
public record Query : IRequest<List<Response>>;
