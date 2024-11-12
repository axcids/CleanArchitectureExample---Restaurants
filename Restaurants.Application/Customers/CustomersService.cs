﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Customers.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Customers;
internal class CustomersService(ICustomerRepository customersRepository,  ILogger<CustomersService> logger, IMapper mapper) : ICustomersService {
    public async Task<int> AddCustomer(AddCustomer addCustomer) {
        var customer = mapper.Map<Customer>(addCustomer);
        var id = await customersRepository.AddCustomer(customer);
        return id;
    }
    public async Task<CustomersDtos> GetCustomerById(int id) {
        var customer  = await customersRepository.GetCustomerById(id);
        var customerDtos = mapper.Map<CustomersDtos>(customer);
        return customerDtos;
    }

    async Task<IEnumerable<CustomersDtos?>> ICustomersService.GetAllCustomers() {
        var customers = await customersRepository.GetAllAsync();
        var customersDtos = mapper.Map<IEnumerable<CustomersDtos>>(customers);
        return customersDtos!;
    }
}
