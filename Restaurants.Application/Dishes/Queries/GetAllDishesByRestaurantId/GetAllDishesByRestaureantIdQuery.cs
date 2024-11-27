using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId; 
public class GetAllDishesByRestaureantIdQuery(int restaurantID) : IRequest<IEnumerable<DishDtos>> {
    public int RestaurantId { get; set; } = restaurantID;
}
