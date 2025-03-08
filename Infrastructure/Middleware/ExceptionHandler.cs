using System.Text.Json;
using ExceptionManager.Model.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            await HandleErrorAsync(httpContext, ex);
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

    private static async Task HandleErrorAsync(HttpContext context, Exception exception)
    {
        var problemDetails = exception switch
        {
            BadRequestException badRequest => new ProblemDetails
            {
                Title = "Bad Request",
                Detail = badRequest.Message + badRequest.Errors.Select((error) => $"{error}\n"),
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Status = StatusCodes.Status400BadRequest,
                // Extensions =
                // {
                //     { "errors", badRequest.Errors }
                // }
            },
            _ => new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = exception.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Status = StatusCodes.Status500InternalServerError
            }
        };
        context.Response.StatusCode = problemDetails.Status!.Value;
        var problemDetailsJson = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(problemDetailsJson);
    }
}