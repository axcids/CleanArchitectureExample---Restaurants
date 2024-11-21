using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System.Reflection.Metadata.Ecma335;

namespace Restaurants.Infrastructure.Repositories;
internal class OrderRepository(RestaurantsDbContext dbContext) : IOrdersRepository {
    public async Task<int> AddNewOrder(Order entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteOrderById(Order entity) {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync() {
        var orders =  dbContext.Orders.ToList();
        return orders;
    }

    public async Task<Order> GetOrderByIdAsync(int id) {
        var orders = dbContext.Orders
            .FirstOrDefault(o => o.Id == id);
        return orders;
    }

    public async Task SaveChanges()=>
         await dbContext.SaveChangesAsync();
    
}
