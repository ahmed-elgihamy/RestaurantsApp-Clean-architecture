using Xunit;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FluentValidation.TestHelper;

namespace Restaurants.Application.Restaurants.Commands.CreatRestaurant.Tests
{
    public class CreateRestaurantCommandValidatorTests
    {
        [Fact()]
        public void Validator_VaildCommand_ShouldNotHaveAnyValidationErrors()
        {

            //arrange
            var command = new CreateRestaurantCommand
            {
                Name = "test",
                Description = "dddddddddddddddddddddd",
                Category = "Italian",
                ContactEmail = "ahmed@gmail.com",
                ContactNumber = "15155848488",
                PostalCode = "45-484"
            };

            var validator = new CreateRestaurantCommandValidator();
            //act

            var results = validator.TestValidate(command);
            //assert
            results.ShouldNotHaveAnyValidationErrors();

        }





        public void Validator_InVaildCommand_ShouldHaveAnyValidationErrors()
        {

            //arrange
            var command = new CreateRestaurantCommand
            {
                Name = "te",
                Description = "",
                Category = "Itali",
                ContactEmail = "@fe",
                ContactNumber = "15155",
                PostalCode = "4584"
            };

            var validator = new CreateRestaurantCommandValidator();
            //act

            var results = validator.TestValidate(command);
            //assert
            results.ShouldHaveValidationErrorFor(r => r.Name);
            results.ShouldHaveValidationErrorFor(r => r.Description);
            results.ShouldHaveValidationErrorFor(r => r.ContactEmail);
            results.ShouldHaveValidationErrorFor(r => r.Category);
            results.ShouldHaveValidationErrorFor(r => r.PostalCode);

        }




        [Theory()]
        [InlineData("Indian")]
        [InlineData("American")]
        [InlineData("Japanese")]
        [InlineData("Mexican")]
        [InlineData("Italian")]

        public void Validator_VaildCommandForCategory_ShouldNotHaveAnyValidationErrors( string Cat)
        {

            //arrange
            var validator = new CreateRestaurantCommandValidator();
            var command = new CreateRestaurantCommand { Category = Cat };
           

            //act

            var results = validator.TestValidate(command);
            //assert
            results.ShouldNotHaveValidationErrorFor(r => r.Category);
        }



        [Theory()]
        [InlineData("222")]
        [InlineData("48-8484")]
        [InlineData("1-4848")]
        [InlineData("22 222")]
        [InlineData("10-58f5")]

        public void Validator_InVaildCommandForPostalCode_ShouldNotHaveAnyValidationErrors(string post)
        {

            //arrange
            var validator = new CreateRestaurantCommandValidator();
            var command = new CreateRestaurantCommand { PostalCode = post };


            //act

            var results = validator.TestValidate(command);
            //assert
            results.ShouldHaveValidationErrorFor(r => r.PostalCode);
        }
    }
}