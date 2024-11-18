using Microsoft.Extensions.Logging;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders;
internal class OrderService(IOrdersRepository ordersRepository, ILogger<RestaurantsService> logger) : IOrdersService {
    public async Task<int> AddOrder(AddOrder entity) {
        var orderMap = new Order {
            CustomerId = entity.CustomerId,
            OrderDate = entity.OrderDate,
            OrderStatus = entity.OrderStatus,
            TotalAmount = entity.TotalAmount
        };
        var id = await ordersRepository.AddNewOrder(orderMap);
        return id;
    }

    public async Task<IEnumerable<OrderDtos>> GetAllOrders() {
        var orders = await ordersRepository.GetAllOrdersAsync();
        var ordersDtos = orders.Select(OrderDtos.FromEntity).ToList();
        return ordersDtos;
    }

    public async Task<OrderDtos> GetOrderById(int id) {
        var order = await ordersRepository.GetOrderByIdAsync(id);
        if (order == null) {
            throw new Exception($"Order with ID {id} not found."); 
        }
        var orderDto = OrderDtos.FromEntity(order);
        return orderDto;
    }
}
