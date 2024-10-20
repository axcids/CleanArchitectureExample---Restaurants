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


}
