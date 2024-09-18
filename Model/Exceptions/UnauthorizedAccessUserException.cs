using System.Net;

namespace ExceptionManager.Model;

public class UnauthorizedAccessUserException() : Exception("Token was expired or incorrect.")
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.Unauthorized;
}
