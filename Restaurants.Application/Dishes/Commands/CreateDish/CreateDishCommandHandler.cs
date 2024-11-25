using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;
public class CreateDishCommandHandler(IRestaurantsRepository restaurantsRepository, IDishRepository dishRepository, ILogger<CreateDishCommandHandler> logger) : IRequestHandler<CreateDishCommand, int> {
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken) {
        var restaurant = restaurantsRepository.GetRestaurantById(request.RestaurantId) 
            ?? throw new NotFoundException($"Restaurant with this ID: {request.RestaurantId} doesn't exist!");
        var dish = new Dish {
            RestaurantId = request.RestaurantId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            KiloCalories = request.KiloCalories
        };
        var id = await dishRepository.CreateNewDish(dish);
        return id;

    }
}
