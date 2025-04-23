
using MediatR;
using Restaurants.Application.Restaurants.DTOs;
using  Restaurants.API.Common;
using Restaurants.Domain.Constants;
namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery():IRequest<PagedResult<RestaurantDto?>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string ? SortBy { get; set; }
    public SortDirection sortDirection { get; set; }
}
 