using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants {
    public interface IRestaurantsService {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurantById(int id);
        Task<String> GetRestaurantNameById(int id);
        Task<IEnumerable<String>> GetAllContacts();
    }
}