using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Orders;
using Restaurants.Application.Orders.Commands.CreateOrder;
using Restaurants.Application.Orders.Commands.DeleteOrder;
using Restaurants.Application.Orders.Commands.UpdateOrder;
using Restaurants.Application.Orders.Commands.UpdateOrderStatus;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Orders.Queries.GetAllOrders;
using Restaurants.Application.Orders.Queries.GetOrderById;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/orders/")]
public class OrderController(IMediator mediator) : Controller {

    #region GET
    [HttpGet]
    [Route("GetAllOrderHeaders")]
    public async Task<IActionResult> GetAllOrderHeaders() {
        var orders = await mediator.Send(new GetAllOrdersQuery());
        return Ok(orders);
    }
    [HttpGet]
    [Route("GetOrderHeaderById")]
    public async Task<IActionResult> GetOrderById(int id) {
        
        var order = await mediator.Send(new GetOrderByIdQuery() {
            Id = id
        });
        return Ok(order);
 
    }
    #endregion
    #region POST

    [HttpPost]
    [Route("AddNewOrderHeader")]
    public async Task<IActionResult> AddOrderHeader([FromBody] CreateOrderCommand command) {
        var id = await mediator.Send(command);
        if (id != default(int)) return Ok(id);
        return null;
    }

    #endregion
    #region Delete
    //Delete
    [HttpDelete]
    [Route("DeleteOrderHeaderById")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrderById(int id) {
        var isDeleted = await mediator.Send(new DeleteOrderCommand(id) {
            Id = id
        });
        if (isDeleted) return NoContent();
        return NotFound();
    }

    #endregion
    #region Update Order Status

    [HttpPatch]
    [Route("ApproveOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ApproveOrder(int id){

        var isApproved = await mediator.Send(new UpdateOrderStatusToApprovedCommand(id) {
            Id = id
        });
        if (isApproved) return NoContent();
        return NotFound();
    }
    [HttpPatch]
    [Route("RejectOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RejectOrder(int id) {
        var isRejected = await mediator.Send(new UpdateOrderStatusToRejectedCommand(id) {
            Id = id
        });
        if (isRejected) return NoContent();
        return NotFound();
    }
    [HttpPatch]
    [Route("DeliverOrder")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult>DeliverOrder(int id) {
        var isDelivered = await mediator.Send(new UpdateOrderStatusToDeliveredCommand(id) {
            Id = id
        });
        if (isDelivered) {
            return NoContent();
        }
        else {
            return NotFound();
        }
    }

    #endregion
}
