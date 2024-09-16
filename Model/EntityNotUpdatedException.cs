namespace ExceptionManager.Model;

public class EntityNotUpdatedException(string message, Exception? innerException = null) : Exception(message, innerException);