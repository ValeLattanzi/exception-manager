using System.Net;

namespace ExceptionManager.Model;

internal class NotFoundException(string? message) : Exception(message)
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
}
