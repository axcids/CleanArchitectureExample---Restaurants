using MediatR;

namespace Restaurants.Application.Orders.Commands.UpdateOrder; 
public class UpdateOrderStatusToApprovedCommand(int id) : IRequest<bool>{
    public int Id { get; set; }
}
