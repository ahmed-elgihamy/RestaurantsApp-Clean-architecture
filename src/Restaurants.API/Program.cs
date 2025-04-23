
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using  Restaurants.Application.Extensions;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Restaurants.API.MiddleWares;
using Restaurants.Domain.Entities;
using Microsoft.OpenApi.Models;
using Restaurants.API.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
    //.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    //.MinimumLevel.Override("Microsoft.EntityFrameWorkCore", LogEventLevel.Information)
    //.WriteTo.File("logs/Restaurant-api-.log",rollingInterval:RollingInterval.Day,rollOnFileSizeLimit:true)
    //.WriteTo.Console(outputTemplate: "[{Timestamp:dd-mm HH:mm:ss} {Level:u3}] |{sourceContext}| {NewLine} {Message:lj}{NewLine}{Exception}")











var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}
app.UseMiddleware<ErrorHandlingMiddleWare>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();
if(app.Environment.IsDevelopment())
{

app.UseSwagger();
app.UseSwaggerUI();

}
app.UseHttpsRedirection();

app.MapGroup("api/identity") 
    .WithTags("Identity")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program();