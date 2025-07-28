using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.API.Customer;
public class GetEndpoint(IMediator mediator) : BaseController
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(
            new Application.Customer.Queries.GetCustomers.Query());
        return Ok(result);
    }

    [HttpGet("{id:guid}/orders")]
    public async Task<IActionResult> GetOrdersByCustomerId(Guid id)
    {
        var result = await mediator.Send(
            new Application.Customer.Queries.GetOrders.Query(id));
        return Ok(result);
    }
}
