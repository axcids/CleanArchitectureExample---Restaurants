using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Restaurants.Application.Customers.Dtos; 
public class CustomersDtos {

    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    [JsonIgnore]
    public RestaurantDtos FavoriteRestaurants { get; set; }
    public String FavoriteRestaurant {  get; set; }

    public static CustomersDtos? FromEntity(Customer? c) {

        if(c == null) return null;
        return new CustomersDtos() {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber,
            City = c.Address.City, 
            Street = c.Address.Street,
            PostalCode = c.Address.PostalCode,
            FavoriteRestaurant = c.Restaurant.Name,
        };

    }

}
