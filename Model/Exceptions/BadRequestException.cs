using ExceptionManager.Pattern.Result;

namespace ExceptionManager.Model;

public abstract class BadRequestException(string message, Error[]? errors = null) : Exception(message)
{
    public Error[] Errors { get;} = errors ?? [];
}