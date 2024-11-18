using Restaurants.Application.Orders.Dtos;

namespace Restaurants.Application.Orders; 
public interface IOrdersService {
    Task<IEnumerable<OrderDtos>> GetAllOrders();
    Task<OrderDtos> GetOrderById(int id);
    Task<int> AddOrder(AddOrder order);

}
