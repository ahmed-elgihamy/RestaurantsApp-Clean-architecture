using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    class DishesRepository(RestaurantDBContext dBContext) : IDishRepository
    {
        public async Task<int> Create(Dish dish)
        {
             dBContext.Dishes.Add(dish);
             await dBContext.SaveChangesAsync();
            return dish.Id;
        }

        public async Task Delete(IEnumerable<Dish> entites)
        {
            dBContext.Dishes.RemoveRange(entites);
           await dBContext.SaveChangesAsync();
        }
    }
}
