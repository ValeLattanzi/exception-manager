namespace ExceptionManager.Model.Exceptions;

public class ServiceUseCaseIsNullException(string serviceName)
    : Exception($"The service {serviceName} cannot be created.")
{
}