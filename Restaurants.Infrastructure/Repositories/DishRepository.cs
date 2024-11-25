using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
internal class DishRepository(RestaurantsDbContext dbContext) : IDishRepository {
    public async Task<int> CreateNewDish(Dish entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Dish>> GetAllDishes() {
        var dishes = dbContext.Dishes.ToList();
        return dishes;
    }

    public async Task<Dish> GetDishById(int Id) {
        var dish = dbContext.Dishes.FirstOrDefault(x => x.Id == Id);
        return dish;
    }

    public async Task<IEnumerable<Dish>> GetDishesByRestaurantId(int RestaurantId) {
        var dishes = dbContext.Dishes
            .Where(x => x.RestaurantId == RestaurantId).ToList();
        return dishes;
    }
}
