using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Authorization;
using System.Security.Claims;

public class RestaurantsUserClaimsPrincipalFactory(
    UserManager<User> userManager,
    RoleManager<IdentityRole> roleManager,
    IOptions<IdentityOptions> options)
    : UserClaimsPrincipalFactory<User, IdentityRole>(userManager, roleManager, options)
{
    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
    {
        var id = await base.GenerateClaimsAsync(user); 

        if (!string.IsNullOrEmpty(user.Nationality))
        {
            id.AddClaim(new Claim(AppClaimType.Nationality, user.Nationality));
        }

        if (user.DateOfBirth != null)
        {
            id.AddClaim(new Claim(AppClaimType.DataofBirth, user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
        }

        return id;
    }
}
