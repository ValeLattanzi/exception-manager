namespace ExceptionManager.Model.Exceptions;

public class EntityNotFoundException(string message) : Exception(message)
{
}