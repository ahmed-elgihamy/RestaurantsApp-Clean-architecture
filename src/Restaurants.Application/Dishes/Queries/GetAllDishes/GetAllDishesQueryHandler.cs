using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetAllDishes
{
    public class GetAllDishesQueryHandler(IRestaurantsRepository restaurantsRepository ,ILogger<GetAllDishesQueryHandler> logger ,IMapper _mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Dishes for Resaurant");

            var restaurant = await restaurantsRepository.GetByIdAsync(request.id);
            if(restaurant ==null)
                throw new NotFoundException(nameof(restaurant), request.id.ToString());

            var resDto = _mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
          
            return resDto;
        }
    }
}
