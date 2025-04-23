using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users.Commands.AssignUserRole;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
  public  class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommand> _logger,
          UserManager<User> _userManager,
          RoleManager<IdentityRole> _roleManager
        ) :IRequestHandler<UnassignUserRoleCommand>
    {
        public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Assign User role: {@request}", request);
            var user = await _userManager.FindByEmailAsync(request.UserEmail)
                             ?? throw new NotFoundException(nameof(User), request.RoleName);

            var role = await _roleManager.FindByNameAsync(request.RoleName)
                             ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);


            await _userManager.RemoveFromRoleAsync(user, role.Name!);
        }
    }
}
