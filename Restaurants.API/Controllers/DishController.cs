using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/Restaurants/{restaurantId}/dishes")]
public class DishController(IMediator mediator) : ControllerBase {
    [HttpPost]
    [Route("AddNewDishToARestaurant")]
    public async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand command) {
        await mediator.Send(command){
            command.RestaurantId = restaurantId;
        }
        return Created();
    }
}
