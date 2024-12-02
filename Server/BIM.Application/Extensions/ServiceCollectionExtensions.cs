using Microsoft.Extensions.DependencyInjection;

namespace BIM.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssemby = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(applicationAssemby));
        services.AddAutoMapper(applicationAssemby);
        services.AddHttpContextAccessor();
    }
}
