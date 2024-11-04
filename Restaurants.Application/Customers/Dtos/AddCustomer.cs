using Restaurants.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Restaurants.Application.Customers.Dtos;
public class AddCustomer {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public int FavoriteRestaurant { get; set; }
    [JsonIgnore]
    public Restaurant? Restaurant { get; set; }


}
