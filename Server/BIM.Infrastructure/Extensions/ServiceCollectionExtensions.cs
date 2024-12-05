using BIM.Domain.Respositories;
using BIM.Infrastructure.Persistence;
using BIM.Infrastructure.Repositories;
using BIM.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BIMDb");
        services.AddDbContext<BIMDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging(configuration.GetValue<bool>("EnableSensitiveDataLogging", false));
        });

        AddCustomServices(services);
    }

    private static void AddCustomServices(IServiceCollection services)
    {
        services.AddScoped<IBookSeeder, BookSeeder>();
        services.AddScoped<RoleSeeder>();
        services.AddScoped<IBooksRepository, BooksRepository>();
    }
}
