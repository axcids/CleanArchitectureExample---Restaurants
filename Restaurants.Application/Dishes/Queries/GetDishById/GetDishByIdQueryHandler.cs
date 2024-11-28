using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishById;
public class GetDishByIdQueryHandler(ILogger<GetDishByIdQuery> logger, IRestaurantsRepository restaurantsRepository, IDishRepository dishRepository) : IRequestHandler<GetDishByIdQuery, DishDtos> {
    public async Task<DishDtos> Handle(GetDishByIdQuery request, CancellationToken cancellationToken) {
        var restaurant = await restaurantsRepository.GetRestaurantById(request.restaurantId)
            ?? throw new NotFoundException($"Restaurant with this ID {request.restaurantId} doesn't exist!");
        var result = restaurant.Dishes.Find(x => x.Id == request.Id)
            ?? throw new NotFoundException($"Dish with this ID {request.Id} doesn't exist!");
        var dishDto = new DishDtos {
            Id = result.Id,
            RestaurantId = result.RestaurantId,
            Name = result.Name,
            Description = result.Description,
            Price = result.Price,
            KiloCalories = result.KiloCalories
        }; 
        return dishDto;
    }
}
