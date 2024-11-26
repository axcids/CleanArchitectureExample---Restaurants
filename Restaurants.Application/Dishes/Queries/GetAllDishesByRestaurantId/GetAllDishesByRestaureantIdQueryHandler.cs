using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;
public class GetAllDishesByRestaureantIdQueryHandler(ILogger<GetAllDishesByRestaureantIdQuery> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllDishesByRestaureantIdQuery, DishDtos> {
    public async Task<DishDtos> Handle(GetAllDishesByRestaureantIdQuery request, CancellationToken cancellationToken) {
        var restaurant = await restaurantsRepository.GetRestaurantById(request.RestaurantId)
            ?? throw new NotFoundException($"Restaurant with this ID {request.RestaurantId} doesn't exist!");
        var dishDto = DishDtos.FromEntity(restaurant.Dishes);
        return dishDto;

    }
}
