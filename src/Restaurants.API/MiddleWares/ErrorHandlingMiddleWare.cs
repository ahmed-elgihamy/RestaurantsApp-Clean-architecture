
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.MiddleWares;

//builder.Services.AddScoped<ErrorHandlingMiddle>();
//app.UseMiddleware<ErrorHandlingMiddle>();

public class ErrorHandlingMiddleWare (ILogger<ErrorHandlingMiddleWare> logger): IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {

          await  next.Invoke(context);
        }
        catch(NotFoundException ex)
        {
            logger.LogError(ex.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(ex.Message);

        }

        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync($"Something went Worng :{ex.Message}");


        }
    }
}
