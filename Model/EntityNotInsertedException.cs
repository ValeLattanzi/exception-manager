namespace ApiArquitect.Exceptions.Infrastructure.Data
{
    public class EntityNotInsertedException(string entity, Type type) : Exception($"The object of type {type.Name} cannot be inserted at the database.\n{entity}")
    {
    }
}
