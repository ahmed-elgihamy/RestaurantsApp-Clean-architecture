using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.AssignUserRole
{
 public   class AssignUserRoleHandler(ILogger<AssignUserRoleHandler> _logger ,
          UserManager<User> _userManager,
          RoleManager<IdentityRole> _roleManager
        ) : IRequestHandler<AssignUserRoleCommand>
    {
        public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Assign User role: {@request}", request);
            var user = await _userManager.FindByEmailAsync(request.UserEmail)
                             ?? throw new NotFoundException(nameof(User), request.RoleName);

            var role = await _roleManager.FindByNameAsync(request.RoleName)
                             ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);


            await _userManager.AddToRoleAsync(user, role.Name!);
        }
    }
}
