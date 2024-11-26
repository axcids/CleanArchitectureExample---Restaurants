using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/Restaurants/{restaurantId}/dishes")]
public class DishController(IMediator mediator) : ControllerBase {
    [HttpPost]
    [Route("AddNewDishToARestaurant")]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand command) {
        command.RestaurantId = restaurantId;
        await mediator.Send(command);
        return Created();
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DishDtos>>> GetAllDishesByRestaurant([FromRoute]int restaurantID) {
        var dishes = await mediator.Send(new GetAllDishesByRestaurantId() {
            restaurantID = restaurantID
        });
        return Ok(dishes);
    }
}
