
using AutoMapper;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurnt;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile:Profile
{

    public RestaurantsProfile()
    {
        CreateMap<UpdateRestaurantCommend, Restaurant>();
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, o => o.MapFrom(
                src => new Address
                {
                    City = src.City,
                    Street = src.Street,
                    PostalCode = src.PostalCode
                }
                ));



        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(r => r.City, o => o.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(r => r.Street, o => o.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(r => r.PostalCode, o => o.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(r => r.Dishes, o => o.MapFrom(src => src.Dishes == null ? null : src.Dishes));
               // .AfterMap((src, dist) =>
               // {
               //     //write any logic
               // })
               //.ReverseMap();


    }
}
