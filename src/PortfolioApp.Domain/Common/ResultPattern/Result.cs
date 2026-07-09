using PortfolioApp.Common.BaseErrors;

namespace PortfolioApp.Domain.Common.ResultPattern;


public class Result<TValue>
{
    private readonly TValue? _value;

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public BaseError? Error { get; }

    private Result(TValue? value)
    {
        IsSuccess = true;
        _value = value;
        Error = null;
    }
    private Result(BaseError error)
    {
        IsSuccess = false;
        _value = default;
        Error = error;
    }

    public TValue Value => IsSuccess ? _value! :
    throw new InvalidOperationException("Cannot access the value of a failed result.");
    public static Result<TValue> Success(TValue value)
    {
        return new Result<TValue>(value);
    }

    public static Result<TValue> Failure(BaseError error)
    {
        return new Result<TValue>(error);
    }
    public static implicit operator Result<TValue>(TValue value) => Success(value);

    public static implicit operator Result<TValue>(BaseError error) => Failure(error);
}