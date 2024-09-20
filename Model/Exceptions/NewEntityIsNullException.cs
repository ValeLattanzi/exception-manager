namespace ExceptionManager.Model.Exceptions;

public class NewEntityIsNullException(Type type, string message)
    : Exception($"Cannot create the object of {type.Name}.\n{message}")
{
}