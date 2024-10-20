using Restaurants.Domain.Entities;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories; 
public interface IRestaurantsRepository {
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<IEnumerable<String>> GetAllContacts();
}
