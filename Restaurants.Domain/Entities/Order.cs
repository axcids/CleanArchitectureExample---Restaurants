namespace Restaurants.Domain.Entities; 
public class Order {

    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string OrderStatus { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
