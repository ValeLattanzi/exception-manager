using ExceptionManager.Pattern.Result;
using Microsoft.AspNetCore.Mvc;

namespace ZTrainer.Patterns.Result.Results;

public static class ApiResults
{
    public static ProblemDetails Problem(ExceptionManager.Pattern.Result.Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException();

        return new ProblemDetails
        {
            Title = GetTitle(result.Error),
            Detail = GetDetail(result.Error),
            Type = GetType(result.Error.Type),
            Status = GetStatusCode(result.Error),
            Extensions = GetErrors(result)
        };
    }

    private static string GetTitle(Error error)
    {
        return error.Type switch
        {
            ErrorType.BadRequest => error.Code,
            ErrorType.Validation => error.Code,
            ErrorType.NotFound => error.Code,
            ErrorType.Conflict => error.Code,
            ErrorType.Unauthorized => error.Code,
            ErrorType.Forbidden => error.Code,
            _ => "Internal Server Error"
        };
    }

    private static string GetDetail(Error error)
    {
        var descriptionHeader = error.Type switch
        {
            ErrorType.BadRequest => error.Description,
            ErrorType.Validation => error.Description,
            ErrorType.NotFound => error.Description,
            ErrorType.Conflict => error.Description,
            ErrorType.Unauthorized => error.Description,
            ErrorType.Forbidden => error.Description,
            _ => "An error occurred while processing your request."
        };
        return descriptionHeader;
    }

    private static string GetType(ErrorType type)
    {
        return type switch
        {
            ErrorType.BadRequest => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            ErrorType.Validation => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            ErrorType.NotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            ErrorType.Conflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
            ErrorType.Unauthorized => "https://tools.ietf.org/html/rfc7235#section-3.1",
            ErrorType.Forbidden => "https://tools.ietf.org/html/rfc7231#section-6.5.3",
            _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };
    }

    private static int GetStatusCode(Error error)
    {
        return error.Type switch
        {
            ErrorType.BadRequest => StatusCodes.Status400BadRequest,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorType.Forbidden => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError
        };
    }

    private static Dictionary<string, object>? GetErrors(ExceptionManager.Pattern.Result.Result result)
    {
        if (result.Error is not ValidationError validationError) return null;

        return new Dictionary<string, object>
        {
            { "errors", validationError.Errors.ToArray() }
        };
    }
}