using MediatR;

namespace Restaurants.Application.Dishes.Commands.CreateDish; 
public class CreateDishCommand(int i) : IRequest<bool>{
    public int RestaurantId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }


}
