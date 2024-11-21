using MediatR;
using System.Text.Json.Serialization;

namespace Restaurants.Application.Orders.Commands.CreateOrder; 
public class CreateOrderCommand : IRequest<int> {
    public int CustomerId { get; set; }
    [JsonIgnore]
    public DateTime OrderDate { get; set; } = DateTime.Now;
    [JsonIgnore]
    public string OrderStatus { get; set; } = "Pending";
    public decimal TotalAmount { get; set; }
}
