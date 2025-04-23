using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteDish
{
  public  class DeleteDishesForRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository ,IDishRepository dishRepository, ILogger<DeleteDishesForRestaurantCommandHandler> logger) : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Deleting all Dishes for Restaurant ID:{request.Id}");

            var restaurant =await restaurantsRepository.GetByIdAsync(request.Id);

            if(restaurant == null) throw new NotFoundException(nameof(restaurant), request.Id.ToString());

            dishRepository.Delete(restaurant.Dishes);

        }
    }
}
