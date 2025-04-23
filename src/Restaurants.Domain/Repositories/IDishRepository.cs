using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
 public   interface IDishRepository
    {

        Task<int> Create(Dish dish);
        Task Delete(IEnumerable<Dish> entites);


    }
}
