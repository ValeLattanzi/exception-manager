using System.Net;

namespace ExceptionManager.Pattern.Result;

public class Result<T>(T? value, HttpStatusCode statusCode, Exception? exception)
{
    #region Attributes
    public T? Value { get; } = value;
    public Exception? Exception { get; } = exception;
    public HttpStatusCode StatusCode { get; } = statusCode;

    public bool IsSuccess => Exception is null;
    public bool IsFailure => Exception is not null;
    #endregion

    #region Responsibilities
    public static Result<T> Success(T value, HttpStatusCode statusCode)
    {
        return new(value, statusCode, null);
    }

    public static Result<T> Failure(Exception exception, HttpStatusCode statusCode)
    {
        return new(default, statusCode, exception);
    }
    #endregion
}
