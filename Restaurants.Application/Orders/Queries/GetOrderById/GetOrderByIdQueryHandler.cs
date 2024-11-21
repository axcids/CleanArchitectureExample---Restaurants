using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Orders.Queries.GetAllOrders;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Queries.GetOrderById;
public class GetOrderByIdQueryHandler(IOrdersRepository ordersRepository, ILogger<GetAllOrdersQuery> logger) : IRequestHandler<GetOrderByIdQuery, OrderDtos> {
    public async Task<OrderDtos> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        var orderDto = OrderDtos.FromEntity(order);
        return orderDto;
    }
}
