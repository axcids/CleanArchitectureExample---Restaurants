using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishById;
public class GetDishByIdQueryHandler(ILogger<GetDishByIdQuery> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetDishByIdQuery, DishDtos> {
    public async Task<DishDtos> Handle(GetDishByIdQuery request, CancellationToken cancellationToken) {
        var restaurant = await restaurantsRepository.GetRestaurantById(request.restaurantId)
            ?? throw new DllNotFoundException();
        var Result = restaurant.dishes(dish => new DishDtos {

            RestaurantId = dish.RestaurantId,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            KiloCalories = dish.KiloCalories
        });
        return Result;
    }
}
