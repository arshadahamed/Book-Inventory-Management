using BIM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BIM.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BIMDb");
        services.AddDbContext<BIMDbContext>(options =>
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());
    }
}
