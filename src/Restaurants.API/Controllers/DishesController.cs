using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteDish;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Application.Dishes.Queries.GetAllDishes;
using Restaurants.Application.Dishes.Queries.GetDishById;

namespace Restaurants.API.Controllers
{
  
    [Route("api/restaurant/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController (IMediator _mediator):ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public   async Task<IActionResult> CreateDish([FromRoute]int restaurantId, CreateDishCommand command)
        {
            command.RestaurantId = restaurantId;
        var dishId=     await  _mediator.Send(command);
            return CreatedAtAction(nameof(GetByIdForRestaurant), new { restaurantId ,dishId} ,null);

        }

        [HttpGet]
        public async Task<ActionResult<DishDto>> GetAllForRestaurant([FromRoute] int restaurantId)
        {
        
         var dishes=  await  _mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return Ok(dishes);

        }

        [HttpGet("{dishId}")]
        public async Task<ActionResult<DishDto>> GetByIdForRestaurant([FromRoute] int restaurantId, int dishId)
        {

            var dishes = await _mediator.Send(new GetDisheByIdForRestaurantQuery(restaurantId, dishId));
            return Ok(dishes);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDishesForRestaurant([FromRoute] int restaurantId)
        {
            await _mediator.Send(new DeleteDishesForRestaurantCommand(restaurantId));
            return NoContent();
        }

    }
}
