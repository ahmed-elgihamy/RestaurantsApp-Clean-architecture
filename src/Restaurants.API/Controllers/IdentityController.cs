using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Application.Users.Commands.UnassignUserRole;
using Restaurants.Application.Users.Commands.UpdateUserDetails;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers
{

    [ApiController ]
    [Route("api/identity")]
    [Authorize]
    public class IdentityController(IMediator _mediator):ControllerBase
    {

        [HttpPatch("User")]
        public async   Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {

             await _mediator.Send(command);
            return NoContent();

        }


        [HttpPost("UserRole")]
        [Authorize(Roles =UserRole.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
        {

            await _mediator.Send(command);
            return NoContent();

        }


        [HttpDelete("UserRole")]
        [Authorize(Roles = UserRole.Admin)]
        public async Task<IActionResult> UnassignUserRole(UnassignUserRoleCommand command)
        {

            await _mediator.Send(command);
            return NoContent();

        }

    }
}
