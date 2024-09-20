namespace ExceptionManager.Model.Exceptions;

public class EntityNotUpdatedException(string message, Exception? innerException = null)
    : Exception(message, innerException);