using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler( ILogger<GetRestaurantByIdQueryHandler> logger ,
    IMapper _mapper ,
    IRestaurantsRepository restaurantsRepository
    ) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting  Restaurant by id {request.Id}");

        var res = await restaurantsRepository.GetByIdAsync(request.Id);

        //  var resDto = RestaurantDto.FromEntity(res);
        var resDto = _mapper.Map<RestaurantDto>(res);
        return resDto;
    }
}
