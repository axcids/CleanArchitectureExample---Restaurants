using Microsoft.OpenApi.Models;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------ Add services to the container
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
 
// ------------------------------------------------------------------------------------Build 
var app = builder.Build();

var scope = app.Services.CreateScope();

var Restaurantseeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
var CustomerSeeder = scope.ServiceProvider.GetRequiredService<ICustomerSeeders>();

await Restaurantseeder.Seed();
await CustomerSeeder.Seed();

// ------------------------------------------------------------------------------------ Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Swagger
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestaurantProject APIs V1"));
app.Run();
