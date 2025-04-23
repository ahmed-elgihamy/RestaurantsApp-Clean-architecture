using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
 public class CreateDishCommendHandler(IMapper _mapper ,IDishRepository _dishRepository,IRestaurantsRepository  restaurantsRepository
        ,ILogger<CreateDishCommendHandler> logger ) : IRequestHandler<CreateDishCommand,int>
    {
        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Create new Dish {@Dish}", request);
            var Restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);
            if (Restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            var dish = _mapper.Map<Dish>(request);

          return  await _dishRepository.Create(dish);
        }
    }
}
