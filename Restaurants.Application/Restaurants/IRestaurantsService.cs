using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants {
    public interface IRestaurantsService {
        Task<IEnumerable<RestaurantDtos>> GetAllRestaurants();
        Task<RestaurantDtos> GetRestaurantById(int id);
        Task<String> GetRestaurantNameById(int id);
        Task<IEnumerable<String>> GetAllContacts();
    }
}