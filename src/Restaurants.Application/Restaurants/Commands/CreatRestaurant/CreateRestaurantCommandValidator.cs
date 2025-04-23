using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.CreatRestaurant
{
    //C:\Users\Ahmed Mahmoud\.nuget\packages\fluentvalidation.aspnetcore\11.3.0\ download and rejester in ServiceCollectionExtensions
  
    public class CreateRestaurantCommandValidator: AbstractValidator<CreateRestaurantCommand>
    {
        private readonly List<string> ValidCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];

        public CreateRestaurantCommandValidator()
        {
            RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(dto => dto.Category)
                .Must(ValidCategories.Contains)
                .WithMessage("Invalid category. Please choose from the valid categories.");

            RuleFor(dto => dto.ContactEmail)
                .NotEmpty().WithMessage("Please provide a valid Email Address.")
                .EmailAddress().WithMessage("Please provide a valid Email format.");

            RuleFor(dto => dto.ContactNumber)
                .NotEmpty().WithMessage("Please provide a valid Phone Number.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Please provide a valid Phone number (10-15 digits).");

            RuleFor(dto => dto.PostalCode)
              .Matches(@"^\d{2}-\d{3}$")
              .WithMessage("Plez provide a vaild PostalCode code:(xx-xxx)");


     
        }
    }
}
