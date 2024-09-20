namespace ExceptionManager.Pattern.Result;

public sealed record ValidationError(string Code, string Description, Error[] Errors)
    : Error(Code, Description, ErrorType.Validation);