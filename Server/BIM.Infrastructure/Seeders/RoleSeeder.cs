using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

public class RoleSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILogger<RoleSeeder> _logger;

    public RoleSeeder(RoleManager<IdentityRole> roleManager, ILogger<RoleSeeder> logger)
    {
        _roleManager = roleManager;
        _logger = logger;
    }

    public async Task SeedRolesAsync()
    {
        var roles = new[] { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(role));
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Role {role} created.");
                }
                else
                {
                    _logger.LogError($"Error creating role {role}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                _logger.LogInformation($"Role {role} already exists.");
            }
        }
    }
}
