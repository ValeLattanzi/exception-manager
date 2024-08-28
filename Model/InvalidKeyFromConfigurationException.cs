namespace ExceptionManager.Model;

public class InvalidKeyFromConfigurationException : Exception
{
    private readonly string _key;

    public InvalidKeyFromConfigurationException(string key) : base($"Cannot read {key} from Configuration")
    {
        _key = key;
    }
}
