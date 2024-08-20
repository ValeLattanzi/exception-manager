using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ExceptionManager.Infrastructure.Middleware;

public interface IExceptionHandlerMiddleware
{
    Task InvokeAsync(HttpContext httpContext);
}

public class ExceptionHandler : IExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandler> _logger;
    private readonly HttpClient _httpClient;

    public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IHttpClientFactory httpClientFactory)
    {
        _next = next;
        _logger = logger;
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:7002");
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled Exception");
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
