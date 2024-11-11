using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Repositories;
internal class OrderRepositories(RestaurantsDbContext dbContext) : IOrdersRepository {
    public async Task<int> AddOrder(Order entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<IEnumerable<Order>> GetAllOrdersAsync() {
        var Orders = await dbContext.Orders
            .Include(r => r.Restaurant)
            .ToListAsync();
        return Orders;
    }
    public async Task<Order> GetOrderById(int id) {
        var order = await dbContext.Orders
            .Include(r => r.Restaurant)
            .FirstOrDefaultAsync(r => r.Id == id);
        return order;
    }
}
