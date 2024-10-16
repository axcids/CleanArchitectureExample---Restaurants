using Microsoft.OpenApi.Models;
using Restaurants.API;
using Restaurants.API.Controllers;
using Restaurants.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------------------------------ Add services to the container
builder.Services.AddControllers();
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddInfrastructure(builder.Configuration);
 
// ------------------------------------------------------------------------------------Build 
var app = builder.Build();

// ------------------------------------------------------------------------------------ Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.Run();
