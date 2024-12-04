using BIM.Domain.Respositories;
using BIM.Infrastructure.Persistence;
using BIM.Infrastructure.Repositories;
using BIM.Infrastructure.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

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
        services.AddScoped<RoleSeeder, RoleSeeder>();
        services.AddScoped<IBooksRepository, BooksRepository>();
    }
}
