using Microsoft.OpenApi.Models;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;
using Restaurants.API.midlewares;
using Restaurants.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------ Add services to the container
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddScoped<ErrorHandlingMiddleware>();
// ------------------------------------------------------------------------------------Build 
var app = builder.Build();
var scope = app.Services.CreateScope();
var Restaurantseeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
var CustomerSeeder = scope.ServiceProvider.GetRequiredService<ICustomerSeeders>();
//Adding the seeders
await Restaurantseeder.Seed();
await CustomerSeeder.Seed();

// ------------------------------------------------------------------------------------ Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseSerilogRequestLogging();
if (app.Environment.IsDevelopment()) {
    //Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantProject APIs V1"));
}
app.UseHttpsRedirection();
app.MapIdentityApi<User>();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.Run();
