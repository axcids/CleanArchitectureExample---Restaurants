using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService {
    public async Task<IEnumerable<String>> GetAllContacts() {
        var contacts = await restaurantsRepository.GetAllContacts();
        return contacts;
    }
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants() {
        var restaurants = await restaurantsRepository.GetAllAsync();
        return restaurants;
    }

    public async Task<Restaurant> GetRestaurantById(int id) {
        logger.LogInformation($"Getting restaurant with this id: {id}");
        var restaurants = await restaurantsRepository.GetRestaurantById(id);
        return restaurants;
    }
    public async Task<String> GetRestaurantNameById(int id) {
        logger.LogInformation($"Getting restaurant name with this id: {id}");
        var restaurants = await restaurantsRepository.GetRestaurantNameById(id);
        return restaurants;
    }
}
