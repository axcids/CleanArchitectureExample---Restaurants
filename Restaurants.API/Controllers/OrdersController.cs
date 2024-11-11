using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Customers.Dtos;
using Restaurants.Application.Customers;

namespace Restaurants.API.Controllers {
    public class OrdersController : Controller {
        public async Task<IActionResult> AddNewOrder([FromBody] AddOrder addOrder) {
            
        }
    }
}
