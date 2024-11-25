using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories; 
public interface IDishRepository {
    
    Task<IEnumerable<Dish>> GetAllDishes();
    Task<Dish> GetDishById(int Id);
    Task<IEnumerable<Dish>> GetDishesByRestaurantId(int RestaurantId);
    Task<int> CreateNewDish(Dish entity);

}
