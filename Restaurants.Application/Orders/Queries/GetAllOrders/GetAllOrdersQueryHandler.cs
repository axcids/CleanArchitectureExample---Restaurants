using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Queries.GetAllOrders;
public class GetAllOrdersQueryHandler(IOrdersRepository ordersRepository, ILogger<GetAllOrdersQuery> logger) : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderDtos>> {
    public async Task<IEnumerable<OrderDtos>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken) {
        var orders = await ordersRepository.GetAllOrdersAsync();
        var ordersDtos = orders.Select(OrderDtos.FromEntity).ToList();
        return ordersDtos;
    }
}
