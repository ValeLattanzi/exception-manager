namespace ExceptionManager.Model;

public class EntityAlreadyExistsException(string message) : Exception(message);