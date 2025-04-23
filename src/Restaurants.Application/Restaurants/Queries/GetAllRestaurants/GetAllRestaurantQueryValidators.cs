

using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQueryValidators:AbstractValidator<GetAllRestaurantsQuery>
{
    private int[] allowPageSizes = [5, 10, 15, 30];
    private string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name), nameof(RestaurantDto.Description), nameof(RestaurantDto.Category)] ;

    public GetAllRestaurantQueryValidators()
    {
        RuleFor(d => d.PageNumber)
           .GreaterThan(0)
           .WithMessage("Must be Greater Than Zero");


        RuleFor(d => d.PageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be in[{string.Join(",", allowPageSizes)}]");


        RuleFor(d => d.SortBy)
        .Must(value => allowedSortByColumnNames.Contains(value))
        .When(d=>d.SortBy !=null)
        .WithMessage($"Sort by is Optional,or must be in [{string.Join(",", allowedSortByColumnNames)}]");






    }
}
