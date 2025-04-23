using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
  public  class GetDisheByIdForRestaurantQueryHandler(IRestaurantsRepository restaurantsRepository, ILogger<GetAllDishesQueryHandler> logger, IMapper _mapper) : IRequestHandler<GetDisheByIdForRestaurantQuery, DishDto>
    {
        public async Task<DishDto> Handle(GetDisheByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Dishe by Id :{@DishId} for Resaurant Id:{@Restaurant}" ,request.DishId ,request.Id);

            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);
            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant), request.Id.ToString());


            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish == null)
                throw new NotFoundException(nameof(dish), request.DishId.ToString());

            var result = _mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
