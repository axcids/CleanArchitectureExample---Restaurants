using Restaurants.Application.Customers.Dtos;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Customers {
    public interface ICustomersService {
        Task<IEnumerable<CustomersDtos>> GetAllCustomers();

    }
}