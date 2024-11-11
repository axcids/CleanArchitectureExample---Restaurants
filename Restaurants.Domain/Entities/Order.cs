using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities; 
public class Order {
    [Key]
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public decimal TotalPrice { get; set; }

}
