using Xunit;
using Restaurants.API.MiddleWares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using FluentAssertions;

namespace Restaurants.API.MiddleWares.Tests
{

    //moq
    //FluentAssertions
    public class ErrorHandlingMiddleWareTests
    {
        [Fact()]
        public async Task InvokeAsync_WhenNoExceptionThrown_ShouldCallNextDelegate()
        {
            // arrange
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleWare>>();
            var middleware = new ErrorHandlingMiddleWare(loggerMock.Object);
            var context = new DefaultHttpContext();
            var nextDelegateMock = new Mock<RequestDelegate>();

            // act
            await middleware.InvokeAsync(context, nextDelegateMock.Object);

            // assert
            nextDelegateMock.Verify(next => next.Invoke(context), Times.Once());
        }

        [Fact]
        public async Task InvokeAsync_WhenNotFoundExceptionThrown_ShouldSetStatusCode404()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleWare>>();
            var middleware = new ErrorHandlingMiddleWare(loggerMock.Object);
            var notFoundException = new NotFoundException(nameof(Restaurant), "1");

            // act
            await middleware.InvokeAsync(context, _ => throw notFoundException);

            // Assert
            context.Response.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task InvokeAsync_WhenExceptionThrown_ShouldSetStatusCode500()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleWare>>();
            var middleware = new ErrorHandlingMiddleWare(loggerMock.Object);
            var notFoundException = new Exception();

            // act
            await middleware.InvokeAsync(context, _ => throw notFoundException);

            // Assert
            context.Response.StatusCode.Should().Be(500);
        }
    }
}