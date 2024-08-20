using System.Net;

namespace ExceptionManager.UseCase.Contract;

public interface ILogExceptions
{
    void Log(Dictionary<Type, HttpStatusCode> exceptions);
}
