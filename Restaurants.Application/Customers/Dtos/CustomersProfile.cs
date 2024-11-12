using AutoMapper;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System.Xml.Serialization;

namespace Restaurants.Application.Customers.Dtos; 
public class CustomersProfile : Profile{

    public CustomersProfile() {

        CreateMap<Customer, CustomersDtos>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.FavoriteRestaurant, opt => opt.MapFrom(src => src.Restaurant.Name));
        
        CreateMap<Restaurant, RestaurantDtos>();

        CreateMap<AddCustomer, Customer>()
            .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address {
                City = src.City,
                Street = src.Street,
                PostalCode = src.PostalCode
            }));

    }


}
