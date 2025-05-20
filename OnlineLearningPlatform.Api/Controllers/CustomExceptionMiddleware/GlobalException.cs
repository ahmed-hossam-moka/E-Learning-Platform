using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningPlatform.Api.Controllers.CustomExceptionMiddleware
{
    public class GlobalException : IExceptionHandler
    {
        private readonly ILogger<GlobalException> _logger;
        public GlobalException(ILogger<GlobalException> logger)
        {
            _logger = logger;
        }

            public async ValueTask<bool> TryHandleAsync(
             HttpContext httpContext,
             Exception exception,
             CancellationToken cancellationToken)
        {
            _logger.LogError(exception, exception.Message);

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            var details = new ProblemDetails()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "API Error",
                Detail = exception.Message,
                Instance = httpContext.Request.Path
            };

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);
            return true;
        }
    }   
}


//public async ValueTask<bool>
//        TryHandleAsync(
//        HttpContext httpContext,
//        Exception exception,
//        CancellationToken cancellationToken
//        )
//{
//    _logger.LogError(exception, exception.Message);

//    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//    httpContext.Response.ContentType = "application/Json";

//    var Details = new ProblemDetails()
//    {
//        Detail = $"API Error {exception.Message}",
//        Instance = "API",
//        Status = (int)HttpStatusCode.InternalServerError,
//        Title = "Api Error",
//        Type = "Server Error"
//    };

//    var ResponseString = JsonSerializer.Serialize(Details);


//    await httpContext.Response.WriteAsync(ResponseString, cancellationToken);

//    return true;

//}
//httpContext.Request.Path