using Xunit;
using Restaurants.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurants.Domain.Constants;
using FluentAssertions;

namespace Restaurants.Application.Users.Tests
{
    public class CurrentUserTests
    {
        //  [Fact()]
        [Theory]
        [InlineData(UserRole.Admin)]
        [InlineData(UserRole.Owner)]
        public void IsInRoleWithMatchingRole_ShoudReturnTrue(string roleName)
        {
            //arrange
            var currentUser = new CurrentUser("1", "ahmed@gmail.com", [UserRole.Admin, UserRole.Owner], null, null);
            //act
            var isInRole = currentUser.IsInRole(roleName);

            //assert
            isInRole.Should().BeTrue();
                
        }

        public void IsInRoleNoWithMatchingRole_ShoudReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "ahmed@gmail.com", [UserRole.Admin, UserRole.Owner], null, null);
            //act
            var isInRole = currentUser.IsInRole(UserRole.User);

            //assert
            isInRole.Should().BeFalse();

        }

        public void IsInRoleNoWithMatchingRoleCase_ShoudReturnFalse()
        {
            //arrange
            var currentUser = new CurrentUser("1", "ahmed@gmail.com", [UserRole.Admin, UserRole.Owner], null, null);
            //act
            var isInRole = currentUser.IsInRole(UserRole.Admin.ToLower());

            //assert
            isInRole.Should().BeFalse();

        }
    }
}