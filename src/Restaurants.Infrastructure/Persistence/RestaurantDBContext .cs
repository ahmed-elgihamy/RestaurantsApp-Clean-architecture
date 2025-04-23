using Restaurants.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Persistence;
    class RestaurantDBContext(DbContextOptions<RestaurantDBContext> options) :IdentityDbContext<User>(options)
    {
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);


        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
             .WithOne()
             .HasForeignKey(r=>r.RestaurantId);


        modelBuilder.Entity<User>()
            .HasMany(r => r.OwendRestaurants)
            .WithOne(r => r.Owner)
            .HasForeignKey(r => r.OwnerId);

        modelBuilder.Entity<Dish>()
        .Property(d => d.Price)
        .HasPrecision(10, 2);
    }

}

