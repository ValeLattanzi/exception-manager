using System.Net;

namespace ExceptionManager.Model.Exceptions;

internal class NotFoundException(string? message) : Exception(message)
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
}