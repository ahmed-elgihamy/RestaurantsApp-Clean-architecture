using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using MediatR;
using System.Threading.Tasks;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurnt;
using Restaurants.Application.Restaurants.DTOs;
using Microsoft.AspNetCore.Authorization;
using Restaurants.Domain.Constants;
using Restaurants.Infrastructure.Authorization;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
   
       [ProducesResponseType(StatusCodes.Status200OK ,Type =typeof(string))]
        public async Task<ActionResult <IEnumerable<RestaurantDto>>> GetAll([FromQuery] GetAllRestaurantsQuery command)
        {
            var restaurants = await _mediator.Send(command);
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
      //  [Authorize(Policy = PolicyName.HasNationality)]

        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles =UserRole.Owner)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand commend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = await _mediator.Send(commend);
            if (id == 0) 
            {
                return BadRequest("Something went wrong after creation.");
            }

      
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        {
             await _mediator.Send(new DeleteRestaurantCommend(id));
             return NoContent();

           
        }


        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> UpdateRestaurant([FromRoute] int id , UpdateRestaurantCommend commend)
        {
            commend.Id = id;
              await _mediator.Send(commend);
           return NoContent();

           
        }
    }
}
