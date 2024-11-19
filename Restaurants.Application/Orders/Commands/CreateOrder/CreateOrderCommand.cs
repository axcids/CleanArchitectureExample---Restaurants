using MediatR;

namespace Restaurants.Application.Orders.Commands.CreateOrder; 
public class CreateOrderCommand : IRequest<int> {
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
    public decimal TotalAmount { get; set; }
}
