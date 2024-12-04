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
        // Configure Authentication and Controllers
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(configuration =>
        {

        });

        builder.Services.AddEndpointsApiExplorer();

        // Register Middleware
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        // Configure Serilog
        builder.Host.UseSerilog((context, configuration) =>
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Is(LogEventLevel.Information)
        );
    }
}
