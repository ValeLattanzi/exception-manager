namespace ExceptionManager.Model.Exceptions;

public class DataContextConfigurationWithErrorException(Exception? innerException = null)
    : Exception("An error was occurred while attempting to configure the database context.", innerException)
{
}