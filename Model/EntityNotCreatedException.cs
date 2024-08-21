namespace ApiArquitect.Exceptions.Infrastructure.Data;

public class EntityNotCreatedException(string useCase, string entity) : Exception($"The use case {useCase} cannot create the object.\n{entity}")
{
}
