using Restaurants.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Restaurants.Application.Customers.Dtos;
public class AddCustomer {
    [StringLength(100, MinimumLength = 3)]
    public string FirstName { get; set; }
    [StringLength(100, MinimumLength =3)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string? PhoneNumber { get; set; } 
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public int RestaurantId{ get; set; }

}
