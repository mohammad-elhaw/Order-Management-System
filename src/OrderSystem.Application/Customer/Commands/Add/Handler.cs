using MediatR;

namespace OrderSystem.Application.Customer.Commands.Add;
public class Handler(
    Infrastructure.Customer.Add.IRepository addRepo) 
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

        var customer = new Domain.Entities.Customer
        {
            Name = request.Name,
            Email = request.Email
        };
        addRepo.Add(customer);
        int saveResult = await addRepo.SaveChanges();

        if (saveResult <= 0)
            throw new Domain.Exceptions.UnHandledException("Failed to add customer");

        return new Response
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email
        };
    }
}
