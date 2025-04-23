using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Constants;

namespace Restaurants.Infrastructure.Seeders;

class RestaurantSeeder(RestaurantDBContext dBContext):IRestaurantSeeder
{

    public async Task Seed()
    {

        if(await dBContext.Database.CanConnectAsync())

        {
            if(! dBContext.Restaurants.Any())
            {
                var restaurants = GenerateRestaurants();
                var res = GetRestaurants();
                dBContext.Restaurants.AddRange(res);
                dBContext.Restaurants.AddRange(restaurants);
                dBContext.SaveChangesAsync();
            }



            if(!dBContext.Roles.Any())
            {

                var roles = GetRoles();
                dBContext.Roles.AddRange(roles);
                await dBContext.SaveChangesAsync();
            }
        }
    }



    private IEnumerable<IdentityRole> GetRoles()
    {

        List<IdentityRole> roles =
            [

            new (UserRole.Admin)
            {
                NormalizedName = UserRole.Admin.ToUpper()
            },
            new (UserRole.Owner)
            {
                NormalizedName = UserRole.Owner.ToUpper()


            },
            new(UserRole.User)
            {
                NormalizedName = UserRole.User.ToUpper()


            }

            ];
        return roles;
    }



    private IEnumerable<Restaurant> GetRestaurants()
    {
        return new List<Restaurant>
    {
        new Restaurant
        {
            Name = "Shawarma Master",
            Description = "Best shawarma in town!",
            Category = "Fast Food",
            HasDelivery = true,
            ContactEmail = "shawarma@master.com",
            ContactNumber = "01012345678",
            Address = new Address
            {
                City = "Alexandria",
                Street = "Main Street",
                PostalCode = "12345"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "Chicken Shawarma", Description = "Marinated chicken with garlic sauce", Price = 50 ,RestaurantId=1},
                new Dish { Name = "Beef Shawarma", Description = "Juicy beef with tahini sauce", Price = 65 ,RestaurantId=1}
            }
        },
        new Restaurant
        {
            Name = "Pasta Paradise",
            Description = "Authentic Italian pasta dishes.",
            Category = "Italian",
            HasDelivery = false,
            ContactEmail = "contact@pastaparadise.it",
            ContactNumber = "01098765432",
            Address = new Address
            {
                City = "Cairo",
                Street = "Tahrir Square",
                PostalCode = "11111"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "Spaghetti Carbonara", Description = "Classic creamy carbonara with bacon", Price = 80,RestaurantId=2 },
                new Dish { Name = "Penne Arrabbiata", Description = "Spicy tomato pasta with chili flakes", Price = 70,RestaurantId=2 },
                new Dish { Name = "Lasagna", Description = "Layered pasta with meat and cheese", Price = 95,RestaurantId=3 }
            }
        },
        new Restaurant
        {
            Name = "Grill House",
            Description = "Meat lovers' heaven with smoky flavors.",
            Category = "Grill",
            HasDelivery = true,
            ContactEmail = "hello@grillhouse.com",
            ContactNumber = "01234567890",
            Address = new Address
            {
                City = "Giza",
                Street = "Pyramids Road",
                PostalCode = "12556"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "Grilled Chicken", Description = "Served with vegetables and garlic sauce", Price = 100,RestaurantId=3 },
                new Dish { Name = "Steak with Herbs", Description = "Tender steak with fresh herbs", Price = 150 ,RestaurantId=2},
                new Dish { Name = "BBQ Ribs", Description = "Slow-cooked ribs with BBQ sauce", Price = 130,RestaurantId=1 }
            }
        },
        new Restaurant
        {
            Name = "Sushi World",
            Description = "Fresh and premium Japanese sushi experience.",
            Category = "Japanese",
            HasDelivery = false,
            ContactEmail = "sushi@world.jp",
            ContactNumber = "01112345678",
            Address = new Address
            {
                City = "New Cairo",
                Street = "90 Street",
                PostalCode = "11865"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "California Roll", Description = "Crab, avocado, cucumber", Price = 120 ,RestaurantId = 3  },
                new Dish { Name = "Salmon Sashimi", Description = "Fresh raw salmon slices", Price = 140  , RestaurantId = 2},
                new Dish { Name = "Tuna Nigiri", Description = "Rice topped with raw tuna", Price = 130   , RestaurantId = 2}
            }
        },
        new Restaurant
        {
            Name = "Falafel Kingdom",
            Description = "Traditional Egyptian flavors made fresh daily.",
            Category = "Oriental",
            HasDelivery = true,
            ContactEmail = "info@falafelkingdom.eg",
            ContactNumber = "01020202020",
            Address = new Address
            {
                City = "Alexandria",
                Street = "Stanley Bridge",
                PostalCode = "21311"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "Falafel Sandwich", Description = "Crispy falafel in fresh baladi bread", Price = 20 , RestaurantId=2 },
                new Dish { Name = "Foul with Oil", Description = "Classic Egyptian foul with olive oil", Price = 15 ,RestaurantId=3 },
                new Dish { Name = "Eggplant with Tahini", Description = "Fried eggplant topped with tahini sauce", Price = 25,RestaurantId=1 }
            }
        },
        new Restaurant
        {
            Name = "Burger Empire",
            Description = "King-size burgers with melting cheese.",
            Category = "Fast Food",
            HasDelivery = true,
            ContactEmail = "burger@empire.com",
            ContactNumber = "01030303030",
            Address = new Address
            {
                City = "Mansoura",
                Street = "Downtown",
                PostalCode = "22666"
            },
            Dishes = new List<Dish>
            {
                new Dish { Name = "Double Cheese Burger", Description = "Double patty, double cheese", Price = 85 ,RestaurantId = 3 },
                new Dish { Name = "Crispy Chicken Burger", Description = "Crunchy fried chicken burger", Price = 75 ,RestaurantId =3 }
            }
        }


    };
    }



    private IEnumerable<Restaurant> GenerateRestaurants()
    {
        var restaurants = new List<Restaurant>();
        var categories = new[] { "Fast Food", "Italian", "Grill", "Japanese", "Oriental" };
        var cities = new[] { "Alexandria", "Cairo", "Giza", "Mansoura", "Tanta" };

        for (int i = 26; i <= 525; i++)
        {
            var restaurant = new Restaurant
            {
                Name = $"Restaurant {i}",
                Description = $"Description for Restaurant {i}",
                Category = categories[i % categories.Length],
                HasDelivery = i % 2 == 0,
                ContactEmail = $"restaurant{i}@email.com",
                ContactNumber = $"010{i:D8}",
                Address = new Address
                {
                    City = cities[i % cities.Length],
                    Street = $"Street {i}",
                    PostalCode = $"{10000 + i}"
                },
                Dishes = new List<Dish>
            {
                new Dish { Name = $"Dish A {i}", Description = $"Tasty dish A {i}", Price = 50 + i % 20, RestaurantId = i },
                new Dish { Name = $"Dish B {i}", Description = $"Delicious dish B {i}", Price = 60 + i % 25, RestaurantId = i },
                new Dish { Name = $"Dish C {i}", Description = $"Yummy dish C {i}", Price = 70 + i % 30, RestaurantId = i }
            }
            };

            restaurants.Add(restaurant);
        }

        return restaurants;
    }
}
