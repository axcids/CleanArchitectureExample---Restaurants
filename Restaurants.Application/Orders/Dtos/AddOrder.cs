namespace Restaurants.Application.Orders.Dtos; 
public class AddOrder {
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string OrderStatus { get; set; }

    public decimal? TotalAmount { get; set; }
}
