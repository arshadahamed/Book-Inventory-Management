using BIM.API.Middlewares;
using Microsoft.OpenApi.Models;
using MIN.API.Middlewares;
using Serilog;
using Serilog.Events;

namespace BIM.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(configuration =>
        {
            configuration.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });
            configuration.AddSecurityRequirement(new OpenApiSecurityRequirement
            {

                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {Type= ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }

            });
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
            configuration
                .ReadFrom.Configuration(context.Configuration)
        );

    }
}
