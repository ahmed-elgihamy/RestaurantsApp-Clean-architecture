using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreatRestaurant
{
   public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger ,
        IMapper _mapper ,
        IRestaurantsRepository restaurantsRepository ,
        IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, int>
    {
        public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var CurrentUser = userContext.GetCurrentUser();
            logger.LogInformation("{UserEmail} [{userId}] is Creating  a new  Restaurant {@Restaurant}",
                
                CurrentUser.Email,
                CurrentUser.Id,
                request);

            var restaurant = _mapper.Map<Restaurant>(request);
            restaurant.OwnerId = CurrentUser.Id;
            int id = await restaurantsRepository.Create(restaurant);
            return id;
        }
    }
}
