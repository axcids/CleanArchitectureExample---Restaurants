using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Orders;
using Restaurants.Application.Orders.Commands.CreateOrder;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Orders.Queries.GetAllOrders;
using Restaurants.Application.Orders.Queries.GetOrderById;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/orders")]
public class OrderController(IMediator mediator) : Controller {

    //GET

    [HttpGet]
    [Route("GetAllOrderHeaders")]
    public async Task<IActionResult> GetAllOrderHeaders() {
        var orders = await mediator.Send(new GetAllOrdersQuery());
        return Ok(orders);
    }
    [HttpGet]
    [Route("GetOrderById")]
    public async Task<IActionResult> GetOrderById(int id) {
        var order = await mediator.Send(new GetOrderByIdQuery() {
            Id = id
        });
        if(order is null) return NotFound();
        return Ok(order);
    }


    //POST

    [HttpPost]
    [Route("AddNewOrderHeader")]
    public async Task<IActionResult> AddOrderHeader([FromBody] CreateOrderCommand command) {
        var id = await mediator.Send(command);
        if (id != default(int)) return Ok(id);
        return null;
    }
}
