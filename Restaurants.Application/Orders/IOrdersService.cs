using Restaurants.Application.Customers.Dtos;
using Restaurants.Application.Orders.Dtos;

namespace Restaurants.Application.Orders; 
public interface IOrdersService {
    Task<int> AddOrder(AddOrder addOrder);
}
