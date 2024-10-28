using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Repositories;
internal class CustomerRepositories(RestaurantsDbContext dbContext) : ICustomerRepository {
    public async Task<IEnumerable<Customer>> GetAllAsync() {
        var customers = await dbContext.Customers
            .Include(r => r.Restaurant)
            .ToListAsync();

        return customers;
    }
}
