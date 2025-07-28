using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.API.Customer;
public class AddEndpoint(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddCustomer(
        [FromBody] Application.Customer.Commands.Add.Request request)
    {
        var result = await mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}
