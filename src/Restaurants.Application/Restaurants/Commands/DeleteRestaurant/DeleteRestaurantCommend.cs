using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
  public  class DeleteRestaurantCommend(int id):IRequest
    {
        public int Id { get; } = id;
    }
}
