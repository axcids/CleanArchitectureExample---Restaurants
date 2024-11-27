using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishById; 
public class GetDishByIdQuery (int restaurantId, int dishId) : IRequest<DishDtos>{
    public int Id { get; set; } = dishId;
    public int restaurantId { get; set; } = restaurantId;
}
