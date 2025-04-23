
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.API.Common;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
    IMapper _mapper , 
    IRestaurantsRepository restaurantsRepository
    ) : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all Restaurants");
        var (restaurants ,TotalCount) = await restaurantsRepository.GetAllMatchingAsync(request.SearchPhrase ,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.sortDirection
            );
       
        //  var resDto = res.Select(RestaurantDto.FromEntity);
        var resDto =  _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        var Result = new PagedResult<RestaurantDto>(resDto, TotalCount, request.PageSize, request.PageNumber);

        return Result;
    } 
}
