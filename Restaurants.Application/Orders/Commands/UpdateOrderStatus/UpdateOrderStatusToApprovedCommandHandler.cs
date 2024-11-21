using MediatR;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders.Commands.UpdateOrder;
public class UpdateOrderStatusToApprovedCommandHandler(IOrdersRepository ordersRepository) : IRequestHandler<UpdateOrderStatusToApprovedCommand, bool> {
    public async Task<bool> Handle(UpdateOrderStatusToApprovedCommand request, CancellationToken cancellationToken) {
        var order = await ordersRepository.GetOrderByIdAsync(request.Id);
        if (order == null) {
            return false;
        }
        order.OrderStatus = "Approved";
        await ordersRepository.SaveChanges();
        return true;
    }
}
