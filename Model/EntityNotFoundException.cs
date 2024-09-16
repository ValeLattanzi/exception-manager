namespace ExceptionManager.Model;

public class EntityNotFoundException(string message) : Exception(message) { }