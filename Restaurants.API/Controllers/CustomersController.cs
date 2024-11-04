using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Customers;
using Restaurants.Application.Customers.Dtos;

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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById([FromRoute] int id) {
        var customer = await customersService.GetCustomerById(id);
        if (customer == null) {
            return NotFound();
        }
        return Ok(customer);
    }
    [HttpPost]
    public async Task<IActionResult> AddNewCustomer([FromBody]AddCustomer addCustomer) {
        var id = await customersService.AddCustomer(addCustomer);
        return CreatedAtAction(nameof(GetCustomerById), new { id }, null);
    } 

}
