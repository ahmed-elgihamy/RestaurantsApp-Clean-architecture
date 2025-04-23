using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommendHandler(ILogger<DeleteRestaurantCommendHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommend>
    {
   

        public async Task Handle(DeleteRestaurantCommend request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleteing Restaurnt Id:{RestaurantId}",request.Id);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant),request.Id.ToString());

            await restaurantsRepository.Delete(restaurant);
      
        }

  
    }
}
