
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using System.Security.Cryptography;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = [];

    //public static RestaurantDto? FromEntity(Restaurant? r)
    //{
    //    if (r == null) return null;

    //    return new RestaurantDto()
    //    {
    //        Id = r.Id,
    //        Name = r.Name,
    //        Description = r.Description,
    //        Category = r.Category,
    //        HasDelivery = r.HasDelivery,
    //        City = r.Address.City,
    //        Street = r.Address.Street,
    //        PostalCode = r.Address.PostalCode,
    //        Dishes =r.Dishes.Select(DishDto.FromEntity).ToList()
    //    };

    //}
}
