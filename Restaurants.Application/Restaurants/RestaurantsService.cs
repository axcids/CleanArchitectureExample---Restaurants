using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService {
    public async Task<IEnumerable<String>> GetAllContacts() {
        var contacts = await restaurantsRepository.GetAllContacts();
        return contacts;
    }

    public async Task<IEnumerable<object>> GetAllRestaurants() {
        var restaurants = await restaurantsRepository.GetAllAsync();

        var aaa = restaurants.Select(f => new { Name = f.Name, DishName = f.Dishes.Select(cc => new { DishName = cc.Name, DishPrice = cc.Price }).ToList() });

        return aaa;
    }
}
