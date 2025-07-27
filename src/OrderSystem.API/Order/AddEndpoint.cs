using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Application.Order.Commands.Add;

namespace OrderSystem.API.Order;
public class AddEndpoint(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] Request request)
    {
        var result = await mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}
