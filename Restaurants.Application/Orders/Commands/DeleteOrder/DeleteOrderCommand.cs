using MediatR;

namespace Restaurants.Application.Orders.Commands.DeleteOrder; 
public class DeleteOrderCommand (int id) : IRequest<bool>{
    public int Id { get; set; }
}
