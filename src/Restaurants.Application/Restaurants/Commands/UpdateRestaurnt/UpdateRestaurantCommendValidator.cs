using FluentValidation;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurnt
{
   public class UpdateRestaurantCommendValidator: AbstractValidator<UpdateRestaurantCommend>
    {
        public UpdateRestaurantCommendValidator()
        {
            RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

        }
    }
}
