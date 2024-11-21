using MediatR;

namespace Restaurants.Application.Orders.Commands.UpdateOrderStatus; 
public class UpdateOrderStatusToDeliveredCommand(int id) : IRequest<bool>{
    public int Id { get; set; }
}
