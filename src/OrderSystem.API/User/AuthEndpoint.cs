using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.API.User;
public class AuthEndpoint(IMediator mediator) : BaseController
{

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Application.User.Commands.Login.Request request)
    {
        var result = await mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Application.User.Commands.Register.Request request)
    {
        var result = await mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}
