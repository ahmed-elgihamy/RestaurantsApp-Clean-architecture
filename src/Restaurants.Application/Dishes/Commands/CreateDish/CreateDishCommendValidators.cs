using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.CreateDish
{
  public  class CreateDishCommendValidators:AbstractValidator<CreateDishCommand>
    {

        public CreateDishCommendValidators()
        {
            RuleFor(dto => dto.Name)
             .NotEmpty().WithMessage("Name is required.")
             .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description is required.");


            RuleFor(dto => dto.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be a non-negtive number.");
            RuleFor(dto => dto.KiloCalories)
              .GreaterThanOrEqualTo(0)
              .WithMessage("KiloCalories must be a non-negtive number.");
        }
    }
}
