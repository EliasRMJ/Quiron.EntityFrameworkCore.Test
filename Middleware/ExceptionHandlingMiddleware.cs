using Quiron.EntityFrameworkCore.Interfaces;
using System.Net;
using System.Text.Json;

namespace Quiron.EntityFrameworkCore.Test.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next
                                           , ILogger<ExceptionHandlingMiddleware> logger
                                           , IMessagesProvider provider)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, provider.Current.UnexpectedOccurred);

            var response = exception switch
            {
                ApplicationException => new ExceptionResponse(HttpStatusCode.BadRequest, provider.Current.BadRequest),
                KeyNotFoundException => new ExceptionResponse(HttpStatusCode.NotFound, provider.Current.NotFound),
                UnauthorizedAccessException => new ExceptionResponse(HttpStatusCode.Unauthorized, provider.Current.Unauthorized),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, provider.Current.InternalServerError)
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;

            var jsonResponse = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}