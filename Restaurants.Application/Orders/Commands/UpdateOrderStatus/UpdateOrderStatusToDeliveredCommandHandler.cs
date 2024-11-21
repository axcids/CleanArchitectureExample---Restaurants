using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.UpdateOrderStatus;
public class UpdateOrderStatusToDeliveredCommandHandler(IOrdersRepository ordersRepository) : IRequestHandler<UpdateOrderStatusToDeliveredCommand, bool> {
    public async Task<bool> Handle(UpdateOrderStatusToDeliveredCommand request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        if(order == null) return false;
        order.OrderStatus = "Delivered";
        await ordersRepository.SaveChanges();
        return true;

    }
}
