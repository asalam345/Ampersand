using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace TaskManagement.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger,RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                //Log the exception
                _logger.LogError(ex, $"{errorId} : {ex.Message}");
                //Return Custom Response

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong"
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class ExceptionHandlerMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    //    }
    //}
}
