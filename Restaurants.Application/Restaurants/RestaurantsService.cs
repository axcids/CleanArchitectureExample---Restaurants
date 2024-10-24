using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
internal class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger) : IRestaurantsService {
    public async Task<IEnumerable<String>> GetAllContacts() {
        var contacts = await restaurantsRepository.GetAllContacts();
        return contacts;
    }
    public async Task<IEnumerable<RestaurantDtos?>> GetAllRestaurants() {
        var restaurants = await restaurantsRepository.GetAllAsync();
        var restaurantsDtos = restaurants.Select(RestaurantDtos.FromEntity);
        return restaurantsDtos!;
    }

    public async Task<RestaurantDtos?> GetRestaurantById(int id) {
        logger.LogInformation($"Getting restaurant with this id: {id}");
        var restaurants = await restaurantsRepository.GetRestaurantById(id);
        var restaurantsDtos = RestaurantDtos.FromEntity(restaurants);
        return restaurantsDtos;
    }
    public async Task<String> GetRestaurantNameById(int id) {
        logger.LogInformation($"Getting restaurant name with this id: {id}");
        var restaurants = await restaurantsRepository.GetRestaurantNameById(id);
        return restaurants;
    }
}
