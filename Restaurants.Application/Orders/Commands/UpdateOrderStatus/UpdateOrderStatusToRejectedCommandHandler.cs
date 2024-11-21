using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.UpdateOrderStatus;
public class UpdateOrderStatusToRejectedCommandHandler(IOrdersRepository ordersRepository, ILogger<UpdateOrderStatusToRejectedCommand> logger) : IRequestHandler<UpdateOrderStatusToRejectedCommand, bool> {
    public async Task<bool> Handle(UpdateOrderStatusToRejectedCommand request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        if (order == null) return false;
        order.OrderStatus = "Rejected";
        await ordersRepository.SaveChanges();
        return true;
    }
}
