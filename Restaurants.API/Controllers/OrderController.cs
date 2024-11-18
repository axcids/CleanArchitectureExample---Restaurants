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
    [HttpGet]
    public async Task<IActionResult> GetOrderById(int id) {
        var OrderId = await ordersService.GetOrderById(id);
        return Ok(OrderId);
    }
    [HttpPost]
    public async Task<IActionResult> AddOrder(AddOrder entity) {
        throw new NotImplementedException();
    }
}
