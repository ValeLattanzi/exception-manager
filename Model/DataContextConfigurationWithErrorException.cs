namespace TestManager.Exceptions;

public class DataContextConfigurationWithErrorException(string message = "") : Exception($"An error was ocurred while attempting to configure the database context.\n{message}")
{
}
