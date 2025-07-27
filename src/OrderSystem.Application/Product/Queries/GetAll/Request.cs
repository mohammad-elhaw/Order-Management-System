using MediatR;

namespace OrderSystem.Application.Product.Queries.GetAll;
public record Request() : IRequest<List<Response>>;
