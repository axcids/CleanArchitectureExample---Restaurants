using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/restaurants")]
public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase{
    [HttpGet]
    public async Task <IActionResult> GetAll() {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet]
    [Route("contacts")]
    public async Task<IActionResult> GetAllContacts() {
        var contacts = await restaurantsService.GetAllContacts();
        return Ok(contacts);
    }
    [HttpGet]
    [Route("GetRestaurantById/{id}")]
    public async Task<IActionResult> GetRestaurantById([FromRoute] int id) {
        var restaurants = await restaurantsService.GetRestaurantById(id);
        if (restaurants is null) {
            return NotFound("Restaurant Not Found");
        }
        else {
            return Ok(restaurants);

        }
    }
    [HttpGet]
    [Route("GetRestaurantNameById/{id}")]
    public async Task<IActionResult> GetRestaurantNameById([FromRoute] int id) {
        var restaurants = await restaurantsService.GetRestaurantNameById(id);
        if (restaurants is null) {
            return NotFound("Restaurant Not Found");
        }
        else {
            return Ok(restaurants);

        }
    }
}
