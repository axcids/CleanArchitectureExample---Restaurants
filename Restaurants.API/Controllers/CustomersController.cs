using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Customers;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/customers")]
public class CustomersController (ICustomersService customersService): Controller {
    [HttpGet]
    [Route("GetAllCustomersFavRest")]
    public async Task<IActionResult> GetAllCustomersFavRest() {
        var customersFavRest = await customersService.GetAllCustomers();
        return Ok(customersFavRest);
    }
}
