using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Customers;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extensions; 
public static class ServiceCollectionExtensions {
    public static void AddApplication(this IServiceCollection services){
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

    }
}
