using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;
internal class CustomerSeeder(RestaurantsDbContext dbContext) : ICustomerSeeders {
    public async Task Seed() {
        if (await dbContext.Database.CanConnectAsync()) {
            if (!dbContext.Customers.Any()) {
                var customers = GetCustomers();
                dbContext.AddRange(customers);
                await dbContext.SaveChangesAsync();
            }
        }
    }
    private IEnumerable<Customer> GetCustomers() {

        List<Customer> customers = [
            new(){
                FirstName = "Mohammed",
                LastName = "Alabdullah",
                Email = "MohammedAlabdullah@gmail.com",
                PhoneNumber = "1234567890",
                Address = new Address(){
                    City="London",
                    Street="Siat st 8",
                    PostalCode="Wd6X AEO"
                },
                Restaurant = dbContext.Restaurants.FirstOrDefault(r=>r.Id == 1)

            }
        ];
        return customers;
    }




}
