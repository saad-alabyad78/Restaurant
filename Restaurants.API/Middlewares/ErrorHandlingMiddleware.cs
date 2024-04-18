using Microsoft.Extensions.Logging;
using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException ex)
            {
                logger.LogWarning("not found");

                context.Response.StatusCode = StatusCodes.Status404NotFound ;
                await context.Response.WriteAsync(ex.Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex , ex.Message );
                
                context.Response.StatusCode = StatusCodes.Status500InternalServerError ;
                await context.Response.WriteAsync("Somethig went wrong");
            }
        }
    }
}