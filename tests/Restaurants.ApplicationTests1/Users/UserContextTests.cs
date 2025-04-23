using Xunit;
using Restaurants.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Restaurants.Domain.Constants;
using FluentAssertions;

namespace Restaurants.Application.Users.Tests;

public class UserContextTests
{
    [Fact()]
    public void GetCurrentUser_WithAuthenticatedUser_ShouldReturnCurrentUser()
    {
        //Moq
        var DataOfBirth = new DateOnly(2002, 2, 2);
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        var claims = new List<Claim>()
        {

            new(ClaimTypes.NameIdentifier,"1"),
           // new(ClaimTypes.Email,"ahmed@gmail.com"),
            new(ClaimTypes.Role,UserRole.Owner),
            new(ClaimTypes.Role,UserRole.Admin),
            new("Nationality","d"),
            new("DataOfBirth",DataOfBirth.ToString("yyyy-MM-dd"))


        };

        var user = new ClaimsPrincipal(new ClaimsIdentity(claims ,"test"));

        httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
        {
            User = user
        });
        var userContext = new UserContext(httpContextAccessorMock.Object);
         //acc

        var currentuser = userContext.GetCurrentUser();
        //asset

        userContext.Should().NotBeNull();
        currentuser.Id.Should().Be("1");
       // currentuser.Email.Should().Be("ahmed@gmail.com");
        currentuser.Roles.Should().ContainInOrder(UserRole.Owner, UserRole.Admin);
        currentuser.Nationality.Should().Be("d");
        currentuser.DataOfBirth.Should().Be(DataOfBirth);
    



}




    [Fact]
    public void GetCurrentUser_WithUserContextNotPresent_ThrowsInvalidOperationException()
    {
        // Arrange
        var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
        httpContextAccessorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);

        var userContext = new UserContext(httpContextAccessorMock.Object);

        // act
        Action action = () => userContext.GetCurrentUser();

        // assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("User context is not present");
    }




}