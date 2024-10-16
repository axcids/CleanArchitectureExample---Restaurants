using Restaurants.Infrastructure.Persistence;
using System.ComponentModel;

namespace Restaurants.Infrastructure.Seeders;
public class RestaurantSeeder(RestaurantsDbContext dbContext) {
    public async Task seed() {
        if (await.dbContext.Database.CanConnectAsync()) {
            if (!dbContext.Restaurants.Any()) {
                var restaurants = GetRestaurants();
            }
        }
    }
    private IEnumerable<Restaurant> GetRestaurants() {
        List<Res> restaurants = [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain",
                HasDelivery = true,
                Dishes =
                [
                    new()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets (5 pcs.)",
                        Price = 5.30M
                    },
                    new()
                    {
                        Name = "Zinger Burger",
                        Description = "Spicy crispy chicken fillet burger with lettuce and mayo.",
                        Price = 7.99M
                    }
                ]
            },
            new()
            {
                Name = "Pizza Hut",
                Category = "Pizza",
                Description = "Pizza Hut is an American multinational restaurant chain known for its Italian-American cuisine.",
                HasDelivery = true,
                Dishes =
                [
                    new()
                    {
                        Name = "Pepperoni Pizza",
                        Description = "Classic pizza topped with pepperoni and mozzarella.",
                        Price = 12.50M
                    },
                    new()
                    {
                        Name = "Cheesy Garlic Bread",
                        Description = "Garlic bread with a cheesy topping, served warm.",
                        Price = 4.99M
                    }
                ]
            }
        ];

    }
}
