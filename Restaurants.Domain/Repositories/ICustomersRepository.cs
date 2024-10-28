using Restaurants.Domain.Entities;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories; 
public interface ICustomerRepository {

    Task<IEnumerable<Customer>> GetAllAsync();

}
