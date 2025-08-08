using MediatR;
using Microsoft.AspNetCore.Identity;

namespace OrderSystem.Application.Customer.Commands.Add;
public class Handler(
    Infrastructure.Customer.Add.IRepository addRepo,
    UserManager<Domain.Entities.User> userManager) 
    : IRequestHandler<Request, Response>
{
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {


        var user = new Domain.Entities.User
        {
            UserName = request.Email.Substring(0, request.Email.IndexOf("@")),
            Email = request.Email,
            FullName = request.Name
        };

        var createUserResult = await userManager.CreateAsync(user, request.Password);
        if (!createUserResult.Succeeded)
        {
            var errors = string.Join(", ", createUserResult.Errors.Select(e => e.Description));
            throw new Domain.Exceptions.UnHandledException($"Failed to create user: {errors}");
        }

        var roleResult = await userManager.AddToRoleAsync(user, "Customer");
        if(!roleResult.Succeeded)
        {
            var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
            throw new Domain.Exceptions.UnHandledException($"Failed to add role: {errors}");
        }


        var customer = new Domain.Entities.Customer
        {
            Name = request.Name,
            Email = request.Email,
            UserId = user.Id,
            User = user
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
