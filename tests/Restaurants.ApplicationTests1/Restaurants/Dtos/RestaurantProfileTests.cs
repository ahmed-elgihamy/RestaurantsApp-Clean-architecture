using Xunit;
using Restaurants.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Restaurants.Domain.Entities;
using Restaurants.Application.Restaurants.DTOs;
using FluentAssertions;
using Restaurants.Application.Restaurants.Commands.CreatRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurnt;

namespace Restaurants.Application.Restaurants.Dtos.Tests
{
    public class RestaurantProfileTests
    {
        private IMapper _mapper;

        public RestaurantProfileTests(IMapper mapper)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RestaurantsProfile>();
            });

            _mapper = mapper;

        }
        [Fact()]
        public void CreateMap_ForRestaurantToRestaurantDto()
        {
            // arrange
   
            var restaurant = new Restaurant()
            {
                Id = 1,
                Name = "Test restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery = true,
                ContactEmail = "test@example.com",
                ContactNumber = "123456789",
                Address = new Address
                {
                    City = "Test City",
                    Street = "Test Street",
                    PostalCode = "12345"
                },
            };


            // act
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            // assert
            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(restaurant.Id);
            restaurantDto.Name.Should().Be(restaurant.Name);
            restaurantDto.Description.Should().Be(restaurant.Description);
            restaurantDto.Category.Should().Be(restaurant.Category);
            restaurantDto.HasDelivery.Should().Be(restaurant.HasDelivery);
            restaurantDto.City.Should().Be(restaurant.Address.City);
            restaurantDto.Street.Should().Be(restaurant.Address.Street);
            restaurantDto.PostalCode.Should().Be(restaurant.Address.PostalCode);
        }




        public void CreateMap_CreateRestaurantCommendToRestaurant()
        {
            // arrange
    
            var command = new CreateRestaurantCommand()
            {
          
                Name = "Test restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery = true,
                ContactEmail = "test@example.com",
                ContactNumber = "123456789",
       
                    City = "Test City",
                    Street = "Test Street",
                    PostalCode = "12345"
               
            };


            // act
            var restaurant= _mapper.Map<Restaurant>(command);

            // assert
            restaurant.Should().NotBeNull();
            restaurant.Name.Should().Be(command.Name);
            restaurant.Description.Should().Be(command.Description);
            restaurant.Category.Should().Be(command.Category);
            restaurant.HasDelivery.Should().Be(command.HasDelivery);
            restaurant.Address.City.Should().Be(command.City);
            restaurant.Address.Street.Should().Be(command.Street);
            restaurant.Address.PostalCode.Should().Be(command.PostalCode);
        }





        public void CreateMap_UpdateRestaurantCommend()
        {
            // arrange

            var command = new UpdateRestaurantCommend()
            {

                Name = "Test restaurant",
                Description = "Test Description",

                HasDelivery = true
            };


            // act
            var restaurant = _mapper.Map<Restaurant>(command);

            // assert
            restaurant.Should().NotBeNull();
            restaurant.Name.Should().Be(command.Name);
            restaurant.Description.Should().Be(command.Description);
            restaurant.HasDelivery.Should().Be(command.HasDelivery);

        }

    }
}