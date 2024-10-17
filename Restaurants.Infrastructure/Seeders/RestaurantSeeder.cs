using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;
internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder {
    public async Task Seed() {
        if (await dbContext.Database.CanConnectAsync()) {
            if (!dbContext.Restaurants.Any()) {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }
    private IEnumerable<Restaurant> GetRestaurants() {
        List<Restaurant> restaurants = [
            new(){
                Name="KFC",
                Category="Fast Food",
                Description="KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain",
                ContactEmail="contact@KFC.com",
                HasDelivery=true,
                Dishes= [
                    new(){
                        Name="Zinger Burger",
                        Description="A spicy chicken burger with crispy lettuce and mayo.",
                        Price = 10.30M
                    },
                    new(){
                        Name="Bucket of Fried Chicken",
                        Description="A mix of crispy fried chicken pieces",
                        Price = 25.99M
                    }

                ],
                Address = new(){
                    City="London",
                    Street="Cork st 5",
                    PostalCode="WC2N SDU"
                }
            },
            new Restaurant(){
                Name = "McDonald's",
                Category = "Fast Food",
                Description = "McDonald's is an American multinational fast food chain",
                ContactEmail = "contact@mcdonalds.com",
                HasDelivery = true,
                //Dishes= [
                //    new(){
                //        Name="Big Mac",
                //        Description="A double-patty burger with lettuce, cheese, and special sauce.",
                //        Price = 12.50M
                //    },
                //    new(){
                //        Name="Chicken McNuggets",
                //        Description="Crispy chicken nuggets with a dipping sauce of choice.",
                //        Price = 8.00M
                //    }

                //],
                Address = new(){
                    City="London",
                    Street="Boots 193",
                    PostalCode="W1F 8SR"
                }

            }
        ];
        return restaurants;
    }

}
