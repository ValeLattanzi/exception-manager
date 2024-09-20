using System.Net;

namespace ExceptionManager.Model.Exceptions;

public class UnauthorizedAccessUserException() : Exception("Token was expired or incorrect.")
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;
}