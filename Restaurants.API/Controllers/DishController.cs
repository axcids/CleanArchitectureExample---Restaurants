using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;

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
    [HttpGet("{dishId}")]
    //[Route("GetDishById")]
    public async Task<ActionResult<IEnumerable<DishDtos>>> GetDishById([FromRoute] int restaurantId, [FromRoute] int dishId) {
        var dishes = await mediator.Send(new GetDishByIdQuery(restaurantId, dishId));
        return Ok(dishes);
    }
    [HttpGet]
    [Route("GetDishesByRestaurantId")]
    public async Task<ActionResult<IEnumerable<DishDtos>>> GetAllDishesByRestaurant([FromRoute]int restaurantId) {
        var dishes = await mediator.Send(new GetAllDishesByRestaureantIdQuery(restaurantId));
        return Ok(dishes);
    }
}
