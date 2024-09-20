namespace ExceptionManager.Model.Exceptions;

public class EntityAlreadyExistsException(string message) : Exception(message);