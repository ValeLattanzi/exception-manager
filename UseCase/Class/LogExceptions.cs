using System.Net;
using ExceptionManager.Model.Exceptions;
using ExceptionManager.UseCase.Contract;

namespace ExceptionManager.UseCase.Class;

public class LogExceptions : ILogExceptions
{
    private readonly Dictionary<Type, HttpStatusCode> _exceptionTypes = new()
    {
        { typeof(UnauthorizedAccessUserException), UnauthorizedAccessUserException.HttpStatusCode },
        { typeof(TypeNotFoundException), TypeNotFoundException.HttpStatusCode },
        { typeof(NotFoundException), NotFoundException.HttpStatusCode },
        { typeof(CannotAddTypeException), CannotAddTypeException.HttpStatusCode }
    };

    public void Log(Dictionary<Type, HttpStatusCode> exceptions)
    {
        foreach (var exception in exceptions)
            if (!_exceptionTypes.TryAdd(exception.Key, exception.Value))
                throw new CannotAddTypeException(exception.Key);
    }
}