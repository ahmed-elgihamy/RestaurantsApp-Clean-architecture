
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Restaurants.Infrastructure.Repositories;

class RestaurantsRepository(RestaurantDBContext dBContext) 
    : IRestaurantsRepository
{
    public async Task<int> Create(Restaurant t)
    {
        dBContext.Restaurants.Add(t);
        await  dBContext.SaveChangesAsync();
        return t.Id;
    }

    public async Task Delete(Restaurant r)
    {
             dBContext.Remove(r);
      await  dBContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var res = await dBContext.Restaurants 
            .Include(r=>r.Dishes)
            .ToListAsync();
        return res;
    }

    public async Task<Restaurant> GetByIdAsync(int id)
    {
        var res = await dBContext.Restaurants
            .Include(r=>r.Dishes)
            .FirstOrDefaultAsync(d => d.Id == id);
        return res;
    }

    public async Task SaveChangesAsync()
    {
      await  dBContext.SaveChangesAsync();
    }


    public async Task<(IEnumerable<Restaurant>,int)> GetAllMatchingAsync(
        string? searchPhrase ,
        int PageSize ,
        int PageNumber,
        string SortBy,
        SortDirection sortDirection
        )
    {
    
        var searchToLower = string.IsNullOrWhiteSpace(searchPhrase) ? null : searchPhrase.Trim().ToLower();

        var baseQuery =  dBContext.Restaurants
           .Where(C => searchToLower == null ||
               C.Name.ToLower().Contains(searchToLower) ||
               C.Description.ToLower().Contains(searchToLower));



        var TotalCount = await baseQuery.CountAsync();

        if(SortBy != null)
        {

            var ColumnSelector = new Dictionary<string, Expression<Func<Restaurant, object>>>
            {
                {nameof(Restaurant.Name),r=>r.Name },
                {nameof(Restaurant.Description),r=>r.Description },
                {nameof(Restaurant.Category),r=>r.Category }
            };
            var SelectedColumn = ColumnSelector[SortBy];

            baseQuery = sortDirection == SortDirection.Ascending
                ? baseQuery.OrderBy(SelectedColumn)
                : baseQuery.OrderByDescending(SelectedColumn);

        }

        var restaurants = await baseQuery
             .Skip(PageSize *(PageNumber-1))
             .Take(PageSize)
            .ToListAsync();
          

        return (restaurants, TotalCount);
    }

}
