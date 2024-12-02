using BIM.Domain.Interfaces;
using BIM.Domain.Respositories;
using BIM.Infrastructure.Authorization.Services;
using BIM.Infrastructure.Persistence;
using BIM.Infrastructure.Repositories;
using BIM.Infrastructure.Seeders;
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

        services.AddScoped<IBookSeeder, BookSeeder>();
        services.AddScoped<IBooksRepository, BooksRepository>();

        services.AddScoped<IBookAuthorizationService, BookAuthorizationService>();

    }
}
