using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Repositories
{
  public  interface IRestaurantsRepository
    {
        Task<Restaurant> GetByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task<int> Create( Restaurant t);
        Task Delete(Restaurant r);
        Task SaveChangesAsync();
        Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int PageSize, int PageNumber ,string? SortBy ,SortDirection sortDirection);



    }
}
