using Microsoft.Extensions.Logging;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders;
internal class OrderService(IOrdersRepository ordersRepository, ILogger<RestaurantsService> logger) : IOrdersService {
    public Task<int> AddOrder(AddOrder order) {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderDtos>> GetAllOrders() {
        var orders = await ordersRepository.GetAllOrdersAsync();
        var ordersDtos = orders.Select(OrderDtos.FromEntity).ToList();
        return ordersDtos;
    }

    public Task<OrderDtos> GetOrderById(int id) {
        throw new NotImplementedException();
    }
}
