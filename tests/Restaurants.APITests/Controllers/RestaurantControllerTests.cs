using Xunit;
using Restaurants.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using FluentAssertions;
using System.Net;

namespace Restaurants.API.Controllers.Tests
{
    public class RestaurantControllerTests:IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public RestaurantControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetById_ForNonExistingId_ShouldReturn404NotFound()
        {
            // arrange
            var id = 1123;

            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync($"/api/restaurants/{id}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAllForValidRequest_returns200Ok()
        {

            var client = _factory.CreateClient();
            var result = await client.GetAsync("/api/Restaurant?PageNumber=2&PageSize=5");
            var content = await result.Content.ReadAsStringAsync();
            Console.WriteLine(content); // Log the response body to see more details
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }


        public async Task GetAllForInValidRequest_returnsBadRequest400()
        {

            var client = _factory.CreateClient();
            var result = await client.GetAsync("/api/Restaurant");


            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }


    }
}