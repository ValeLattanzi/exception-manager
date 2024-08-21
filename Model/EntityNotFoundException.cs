namespace ApiArquitect.Exceptions.Infrastructure.Data;

public class EntityNotFoundException(Type type) : Exception($"Not found the object of {type.Name}.") { }