using System.Net;

namespace ExceptionManager.Model;

public class TypeNotFoundException() : Exception("The type of exception is not provided.")
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
}
