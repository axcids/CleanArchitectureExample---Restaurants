using System.ComponentModel.DataAnnotations;

namespace Restaurants.Domain.Entities; 
public class Order {
    [Key]
    public int Id { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Dish> Dishes { get; set; }
    public decimal TotalPrice { get; set; }

}
