namespace ApiArquitect.Exceptions.Infrastructure.Data;

public class NewEntityIsNullException(Type type, string message) : Exception($"Cannot create the object of {type.Name}.\n{message}")
{
}
