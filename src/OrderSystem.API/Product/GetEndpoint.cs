using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.Application.Product.Queries.GetAll;

namespace OrderSystem.API.Product;
public class GetEndpoint(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productsResponse = await mediator.Send(new Request());
        
        return Ok(productsResponse);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var productResponse = await mediator.Send(
            new Application.Product.Queries.GetById.Request { Id = id });
        
        return Ok(productResponse);

    }
}
