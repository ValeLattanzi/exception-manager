namespace ExceptionManager.Pattern.Result;

public sealed record Error(string title, string description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Null Value", "Value cannot be null");
}