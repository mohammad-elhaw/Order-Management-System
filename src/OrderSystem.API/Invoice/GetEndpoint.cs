using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.API.Invoice;
public class GetEndpoint(IMediator mediator) : BaseController
{

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new Application.Invoices.Queries.GetAll.Query());
        return Ok(result);
    }

    [HttpGet("id:guid")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new Application.Invoices.Queries.GetById.Query(id));
        return Ok(result);
    }
}
