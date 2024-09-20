using ExceptionManager.Pattern.Result;

namespace ExceptionManager.Model.Exceptions;

public abstract class BadRequestException(string message, Error[]? errors = null) : Exception(message)
{
    public Error[] Errors { get; } = errors ?? [];
}