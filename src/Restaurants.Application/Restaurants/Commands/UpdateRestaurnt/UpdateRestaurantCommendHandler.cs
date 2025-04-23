using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurnt
{
    class UpdateRestaurantCommendHandler(ILogger<DeleteRestaurantCommendHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<UpdateRestaurantCommend>
    {



        public async Task Handle(UpdateRestaurantCommend request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updateing Restaurnt Id:{RestaurantId} with {@UpdateRestaurant}", request.Id,request);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                throw new NotFoundException(nameof(restaurant), request.Id.ToString());

            mapper.Map(request, restaurant);

            restaurantsRepository.SaveChangesAsync();

        }
    }
}
