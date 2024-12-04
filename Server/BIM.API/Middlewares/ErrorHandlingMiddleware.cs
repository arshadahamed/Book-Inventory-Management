using BIM.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace MIN.API.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        // Constructor injection
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException notFound)
            {
                context.Response.StatusCode = 404;
                context.Response.ContentType = "application/json";
                var response = new { message = notFound.Message };
                await context.Response.WriteAsJsonAsync(response);

                _logger.LogWarning(notFound.Message);
            }
            catch (ForbidException forbid)
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                var response = new { message = "Access forbidden", details = forbid.Message };
                await context.Response.WriteAsJsonAsync(response);

                _logger.LogWarning(forbid.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var response = new { message = "Something went wrong", error = ex.Message };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
