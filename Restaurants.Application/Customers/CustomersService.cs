using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Customers.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Customers;
internal class CustomersService(ICustomerRepository customersRepository, ILogger<CustomersService> logger, IMapper mapper) : ICustomersService{
    async Task<IEnumerable<CustomersDtos?>> ICustomersService.GetAllCustomers() {
        var customers = await customersRepository.GetAllAsync();
        var customersDtos = mapper.Map<IEnumerable<CustomersDtos>>(customers);
        return customersDtos!;
    }
}
