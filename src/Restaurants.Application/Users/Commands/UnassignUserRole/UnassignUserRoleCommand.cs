using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users.Commands.UnassignUserRole
{
public class UnassignUserRoleCommand:IRequest
    {
        public string UserEmail { get; set; } = default;
        public string RoleName { get; set; } = default;


    }
}
