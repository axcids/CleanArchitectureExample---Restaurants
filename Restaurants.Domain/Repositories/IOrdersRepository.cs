using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories; 
public interface IOrdersRepository {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderById(int id);
    Task<int> AddOrder(Order entity);
}
