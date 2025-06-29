namespace Common.Results;

public class Result<TValue, TError>
{
    public Result(TValue value)
    {
        IsSuccess = true;
        Value = value;
        Error = default;
    }

    public Result(TError error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }
    
    public readonly TValue? Value;
    public readonly TError? Error;

    public readonly bool IsSuccess;

    public static implicit operator Result<TValue, TError>(TValue value) => 
        new Result<TValue, TError>(value);

    public static implicit operator Result<TValue, TError>(TError error) => 
        new Result<TValue, TError>(error);

    public Result<TValue, TError> Match(Func<TValue, Result<TValue, TError>> success,
        Func<TError, Result<TValue, TError>> failure) => IsSuccess ? success(Value!) : failure(Error!);
}