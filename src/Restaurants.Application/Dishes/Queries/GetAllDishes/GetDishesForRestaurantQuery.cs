using MediatR;
using Restaurants.Application.Dishes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
  public  class GetDishesForRestaurantQuery (int restaurantId) :IRequest<IEnumerable<DishDto>>
    {
        public int id { get;  } = restaurantId;
    }
}
