using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.CreateOrder;
public class CreateOrderCommandHandler(IOrdersRepository ordersRepository, ILogger<CreateOrderCommandHandler> logger) : IRequestHandler<CreateOrderCommand, int> {
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
        var orderMap = new Order {
            CustomerId = request.CustomerId,
            OrderDate = request.OrderDate,
            OrderStatus = request.OrderStatus,
            TotalAmount = request.TotalAmount
        };
        var id = await ordersRepository.AddNewOrder(request);
        return id;
    }
}
