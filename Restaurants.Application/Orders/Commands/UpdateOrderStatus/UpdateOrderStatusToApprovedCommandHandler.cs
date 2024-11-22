using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.UpdateOrder;
public class UpdateOrderStatusToApprovedCommandHandler(IOrdersRepository ordersRepository, ILogger<UpdateOrderStatusToApprovedCommand> logger) : IRequestHandler<UpdateOrderStatusToApprovedCommand, bool> {
    public async Task<bool> Handle(UpdateOrderStatusToApprovedCommand request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        logger.LogInformation("Getting order information from database with id = {orderID}", request.Id);
        if (order == null) {
            return false;
        }
        order.OrderStatus = "Approved";
        await ordersRepository.SaveChanges();
        //log here
        return true;
    }
}
