using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Customers;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Restaurants.Application.Orders;

namespace Restaurants.Application.Extensions; 
public static class ServiceCollectionExtensions {
    public static void AddApplication(this IServiceCollection services){
        var applicatrionAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddScoped<IRestaurantsService, RestaurantsService>();
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicatrionAssembly));
        services.AddAutoMapper(applicatrionAssembly);
        services.AddValidatorsFromAssembly(applicatrionAssembly).AddFluentValidation(); ;

    }
}
