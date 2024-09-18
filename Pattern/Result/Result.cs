using System.Net;

namespace ExceptionManager.Pattern.Result;

public class Result<T>
{
    public Result(bool isSuccess, Error error, T? value = default)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Success result can't have an error");
        }

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    #region Attributes
    public T? Value { get; }
    public Error Error { get; }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    #endregion

    #region Responsibilities
    public static Result<T> Success(T? value = default)
    {
        return new Result<T>(true, Error.None, value);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(default, error);
    }
    #endregion
}
