using Restaurants.Domain.Entities;

namespace Restaurants.Application.Orders.Dtos; 
public class OrderDtos {
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; } = default(DateTime?);

    public string OrderStatus { get; set; }

    public decimal? TotalAmount { get; set; }

    public static OrderDtos? FromEntity(Order? order) {
        if (order == null) return null;
        return new OrderDtos() {
            Id = order.Id,
            CustomerId = order.CustomerId,
            OrderDate = order.OrderDate,
            OrderStatus = order.OrderStatus,
            TotalAmount = order.TotalAmount
        };
    }
}
