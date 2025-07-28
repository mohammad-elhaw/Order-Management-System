using MediatR;

namespace OrderSystem.Application.Invoices.Queries.GetById;
public record Query(Guid Id) : IRequest<Response>;
