using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories; 
public interface IOrderDetailsRepository {
    Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
    Task<OrderDetail> GetOrderDetailById(int id);
    Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    Task<int> AddNewOrderDetails(OrderDetail entity);
}
