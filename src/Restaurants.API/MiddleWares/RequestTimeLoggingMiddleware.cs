
using System.Diagnostics;

namespace Restaurants.API.MiddleWares
{

    //builder.Services.AddScoped<RequestTimeLoggingMiddleware>();
    //app.UseMiddleware<RequestTimeLoggingMiddleware>();
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware

    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stopWitch = Stopwatch.StartNew();
            await next.Invoke(context);
            stopWitch.Stop();


            if(stopWitch.ElapsedMilliseconds /1000 >4)
            {
                logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms",
                    context.Request.Method,
                    context.Request.Path,
                    stopWitch.ElapsedMilliseconds);

              //  throw new Exception("time exsited");
            }

        }
    }
}
