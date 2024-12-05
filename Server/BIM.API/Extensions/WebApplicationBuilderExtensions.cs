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
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(configuration =>
        {

        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Services.AddScoped<RequestTimeLoggingMiddleware>();

        builder.Host.UseSerilog((context, configuration) =>
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .MinimumLevel.Is(LogEventLevel.Information)
        );
    }
}
