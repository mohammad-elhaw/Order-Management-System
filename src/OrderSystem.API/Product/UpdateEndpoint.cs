using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Application.Product.Commands.Update;

namespace OrderSystem.API.Product;
public class UpdateEndpoint(IMediator mediator) : BaseController
{
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id,
        [FromBody] Request request)
    {
        var result = await mediator.Send(request with { Id = id});

        return Ok(result);
    }
}
