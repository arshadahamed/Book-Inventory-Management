using BIM.API.Extensions;
using BIM.API.Middlewares;
using BIM.Application.Extensions;
using BIM.Infrastructure.Extensions;
using MIN.API.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Seed roles during startup
var scope = app.Services.CreateScope();
var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
await roleSeeder.SeedRolesAsync();

// Use custom middlewares
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestTimeLoggingMiddleware>();
app.UseSerilogRequestLogging();

// HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    Console.WriteLine("Authentication started.");
    await next.Invoke();
    Console.WriteLine("Authentication completed.");
});

app.UseAuthentication();
app.UseAuthentication(); 

app.UseAuthorization(); 

app.MapControllers();

app.Run();
