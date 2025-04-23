using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Authorization;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services ,IConfiguration conf)
        {
            var connection = conf.GetConnectionString("RestaurantDB");
            services.AddDbContext<RestaurantDBContext>(d => d.UseSqlServer(connection));

            services.AddIdentityApiEndpoints<User>()
                .AddRoles<IdentityRole>()
            .AddClaimsPrincipalFactory<RestaurantsUserClaimsPrincipalFactory>()
                .AddEntityFrameworkStores<RestaurantDBContext>();
               
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
            services.AddScoped<IDishRepository, DishesRepository>();

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyName.HasNationality, builder => builder.RequireClaim(AppClaimType.Nationality,"Egption","German"));
        }
    }
}
