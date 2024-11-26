using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId; 
public class GetAllDishesByRestaureantIdQuery : IRequest<DishDtos>{
    public int RestaurantId { get; set; }
}
