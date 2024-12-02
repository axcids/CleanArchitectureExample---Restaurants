using Microsoft.OpenApi.Models;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
using Restaurants.API.midlewares;
using Restaurants.Domain.Entities;
using System.Security.Cryptography.Xml;
using Restaurants.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------ Add services to the container
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.AddPresentation();

// ------------------------------------------------------------------------------------ Build 
var app = builder.Build();

// Seeding data using a scoped service
using (var scope = app.Services.CreateScope()) {
    var restaurantSeeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    var customerSeeder = scope.ServiceProvider.GetRequiredService<ICustomerSeeders>();

    // Adding the seeders
    await restaurantSeeder.Seed();
    await customerSeeder.Seed();
}

// ------------------------------------------------------------------------------------ Configure the HTTP request pipeline.

// Middleware for error handling
app.UseMiddleware<ErrorHandlingMiddleware>();

// Enable request logging
app.UseSerilogRequestLogging();

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Routing configuration
app.UseRouting();

// Enable Authorization after routing is configured
app.UseAuthorization();

// Swagger configuration for development environment
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantProject APIs V1"));
}

// Map routes for identity and controllers
app.MapGroup("api/identity").MapIdentityApi<User>();
app.MapControllers();

// Run the application
app.Run();

