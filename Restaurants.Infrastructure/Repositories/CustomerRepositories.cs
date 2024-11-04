using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Repositories;
internal class CustomerRepositories(RestaurantsDbContext dbContext) : ICustomerRepository {
    public async Task<int> AddCustomer(Customer entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync() {
        var customers = await dbContext.Customers
            .Include(r => r.Restaurant)
            .ToListAsync();

        return customers;
    }

    public async Task<Customer> GetCustomerById(int id) {
        var customer = await dbContext.Customers
             .Include(r => r.Restaurant)
             .FirstOrDefaultAsync(d => d.Id == id);
        return customer;
    }
}
