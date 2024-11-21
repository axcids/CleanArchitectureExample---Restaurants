using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.DeleteOrder;
public class DeleteOrderCommandHandler(ILogger<DeleteOrderCommandHandler> logger, IOrdersRepository ordersRepository) : IRequestHandler<DeleteOrderCommand, bool> {
    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken) {
        logger.LogInformation($"Deleting Order with ID : {request.Id}");
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        if (order == null) {
            return false;
        }
        await ordersRepository.DeleteOrderById(order);
        return true;
    }
}
