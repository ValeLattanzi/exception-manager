namespace ExceptionManager.Pattern.Result;

public static class ResultExtensions
{
    public static TOut Match<TOut>(
        this Result result,
        Func<TOut> onSuccess,
        Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }

    public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> bind)
    {
        return result.IsSuccess ? bind(result.Value) : Result.Failure<TOut>(result.Error);
    }

    public static Result<TOut> TryCatch<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func, Error error)
    {
        try
        {
            return result.IsSuccess ? Result.Success(func(result.Value)) : Result.Failure<TOut>(result.Error);
        }
        catch
        {
            return Result<TOut>.Failure(error);
        }
    }

    public static Result<TIn> Tap<TIn>(this Result<TIn> result, Action<TIn> action)
    {
        if (result.IsSuccess)
            action(result.Value);

        return result;
    }
}