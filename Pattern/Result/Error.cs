namespace ExceptionManager.Pattern.Result;

public record Error(string Code, string Description, ErrorType Type)
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.None);

    public static readonly Error NullValue = new("Null Value", "Value cannot be null", ErrorType.Validation);

    public static implicit operator Result(Error error)
    {
        return Result.Failure(error);
    }
}

public enum ErrorType
{
    None,
    NotFound,
    BadRequest,
    Unauthorized,
    Forbidden,
    Conflict,
    Validation
}