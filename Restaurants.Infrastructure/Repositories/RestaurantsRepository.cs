using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;


namespace Restaurants.Infrastructure.Repositories;
internal class RestaurantsRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository {
    public async Task<IEnumerable<Restaurant>> GetAllAsync() {
        var restaurants = await dbContext.Restaurants.Include(d => d.Dishes).ToListAsync();

        return restaurants;
    }
    public async Task<IEnumerable<String>> GetAllContacts() {
        var contacts = await dbContext.Restaurants.Select(col => col.ContactEmail).ToListAsync();
        return contacts;
    }

    public async Task<Restaurant> GetRestaurantById(int id) {
        var restaurants = await dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        return restaurants;
    }
    public async Task<String> GetRestaurantNameById(int id) {
        var restaurants = await dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        return restaurants.Name.ToString();
    }
}
