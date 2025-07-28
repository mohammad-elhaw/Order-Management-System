using MediatR;

namespace OrderSystem.Application.Invoices.Queries.GetAll;
public record Query: IRequest<List<Response>>;
