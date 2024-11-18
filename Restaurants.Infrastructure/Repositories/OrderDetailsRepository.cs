using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;
internal class OrderDetailsRepository(RestaurantsDbContext dbContext) : IOrderDetailsRepository {
    public async Task<int> AddNewOrderDetails(OrderDetail entity) {
        dbContext.Add(entity);
        dbContext.SaveChanges();
        return entity.Id;
    }

    public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync() {
        var orderDetails = dbContext.OrderDetails.ToList();
        return orderDetails;
    }

    public async Task<OrderDetail> GetOrderDetailById(int id) {
        var orderDetails = dbContext.OrderDetails
            .FirstOrDefault(x => x.Id == id);
        return orderDetails;
    }

    public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId) {
        var orderDetails = await dbContext.OrderDetails
            .Where(o => o.OrderId == orderId).ToListAsync();
        return orderDetails;
    }
}
