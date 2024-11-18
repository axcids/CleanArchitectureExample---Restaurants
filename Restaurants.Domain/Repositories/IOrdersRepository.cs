using Restaurants.Domain.Entities;


namespace Restaurants.Domain.Repositories; 
public interface IOrdersRepository {
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<int> AddNewOrder(Order entity);
}
