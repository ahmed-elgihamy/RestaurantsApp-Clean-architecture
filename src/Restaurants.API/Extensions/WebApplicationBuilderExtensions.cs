using Microsoft.OpenApi.Models;
using Restaurants.API.MiddleWares;
using Serilog;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtensions
{

    public static void AddPresentation(this WebApplicationBuilder builder)
    {

        builder.Services.AddAuthentication();
        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(
          c =>
          {
              c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
              {

                  Type = SecuritySchemeType.Http,
                  Scheme = "bearer"
              });
              c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
           {

               new OpenApiSecurityScheme
               {
                   Reference =new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="bearerAuth"}
               },
               []
           }
           });


          });
        builder.Host.UseSerilog((context, c) =>c.ReadFrom.Configuration(context.Configuration));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ErrorHandlingMiddleWare>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();



    }
}
