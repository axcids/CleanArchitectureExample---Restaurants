using Restaurants.Domain.Entities;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories; 
public interface IRestaurantsRepository {
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant> GetRestaurantById(int id);
    Task<String> GetRestaurantNameById(int id);
    Task<IEnumerable<String>> GetAllContacts();
}
