using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Application.Orders.Queries.GetAllOrders;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Queries.GetOrderById;
public class GetOrderByIdQueryHandler(IOrdersRepository ordersRepository, ILogger<GetAllOrdersQuery> logger) : IRequestHandler<GetOrderByIdQuery, OrderDtos> {
    public async Task<OrderDtos> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        if (order == null) {
            throw new Exception($"Order with ID {request.Id} not found.");
        }
        var orderDto = OrderDtos.FromEntity(order);
        return orderDto;
    }
}
