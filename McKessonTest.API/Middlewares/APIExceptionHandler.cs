using McKessonTest.API.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace McKessonTest.API.Middlewares
{
    public class APIExceptionHandler(ILogger<APIExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception,exception.Message);

            var response = new ErrorResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ExceptionMessage = "Internal Server Error",
                Title = "Internal Server Error"
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
