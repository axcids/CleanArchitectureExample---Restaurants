using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Customers;
using Restaurants.Application.Customers.Dtos;
using Restaurants.Application.Orders.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Orders;
internal class OrderService(IOrdersRepository ordersRepository,ICustomerRepository customerRepository,IRestaurantsRepository restaurantsRepository ,ILogger<CustomersService> logger, IMapper mapper) : IOrdersService {
    public async Task<int> AddOrder(AddOrder addOrder) {
        var restaurant = GetRestaurant(addOrder.Id);
        var customer = GetCustomer(addOrder.Id);
        addOrder.Restaurant = restaurant;

        var order = await mapper.Map<Order>(addOrder);
        var id = ordersRepository.AddOrder(order);
        return id;
    }
    public Task<Restaurant> GetRestaurant(int addCustomer) {
        var restaurant = restaurantsRepository.GetRestaurantById(addCustomer);
        return restaurant;
    }
    public Task<Customer> GetCustomer(int addCustomer) {
        var customer = customerRepository.GetCustomerById(addCustomer);
        return customer;
    }
}
