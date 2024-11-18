using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Orders;
using Restaurants.Application.Orders.Dtos;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/orders")]
public class OrderController(IOrdersService ordersService) : Controller {
    [HttpGet]
    public async Task<IActionResult> GetAllOrders() {
        var orders = await ordersService.GetAllOrders();
        return Ok(orders);
    }
    [HttpPost]
    [Route("AddNewOrder")]
    public async Task<IActionResult> AddOrder([FromBody] AddOrder entity) {
        var id = await ordersService.AddOrder(entity);
        if(id != default(int)) return Ok(id);
        return null;
    }
}
