using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Users
{


  public  class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {


        public CurrentUser? GetCurrentUser()
        {

            var user = httpContextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not Present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
            var Nationality = user.FindFirst(d => d.Type == "Nationality")?.Value;
            var dataOfBirthString = user.FindFirst(d => d.Type == "DataOfBirth")?.Value;

            var dataOfBirth = dataOfBirthString == null
                ? (DateOnly?)null
                : DateOnly.ParseExact(dataOfBirthString, "yyyy-MM-dd");
            return new CurrentUser(userId, email, roles ,Nationality,dataOfBirth);
        }

    }
}
