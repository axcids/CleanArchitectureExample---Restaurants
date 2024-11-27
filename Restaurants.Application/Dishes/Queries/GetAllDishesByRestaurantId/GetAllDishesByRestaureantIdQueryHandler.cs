using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;
public class GetAllDishesByRestaureantIdQueryHandler(ILogger<GetAllDishesByRestaureantIdQuery> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetAllDishesByRestaureantIdQuery, IEnumerable<DishDtos>> {
    public async Task<IEnumerable<DishDtos>> Handle(GetAllDishesByRestaureantIdQuery request, CancellationToken cancellationToken) {
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId)
           ?? throw new NotFoundException($"Restaurant with this ID {request.RestaurantId} doesn't exist!");
        var results = restaurant.Dishes.Select(dish => new DishDtos {
            Id = dish.Id,
            RestaurantId = dish.RestaurantId,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
            KiloCalories = dish.KiloCalories
        });
        return results;
    }
}
