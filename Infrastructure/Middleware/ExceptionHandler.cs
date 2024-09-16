using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ExceptionManager.Infrastructure.Middleware;

public interface IExceptionHandlerMiddleware
{
    Task InvokeAsync(HttpContext httpContext);
}

public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger) : IExceptionHandlerMiddleware
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled Exception");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        var result = new { message = $"{exception.Message}" };
        var json = JsonSerializer.Serialize(result);
        return context.Response.WriteAsync(json);
    }
}
