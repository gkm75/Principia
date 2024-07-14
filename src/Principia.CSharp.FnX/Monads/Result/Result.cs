using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// Base interface for all Result type monads
/// </summary>
public interface IResult : IMonad
{
    /// <summary>
    /// Property to indicate if the result type is an Ok
    /// </summary>
    bool IsOk { get; }
    
    /// <summary>
    /// Property to indicate if the result type is a Fail
    /// </summary>
    bool IsFail { get; }
}

/// <summary>
/// Base interface for generic type result
/// </summary>
/// <typeparam name="TOk">Type of the Ok values</typeparam>
/// <typeparam name="TFail">Type of the Fail values</typeparam>
public interface IResult<TOk, TFail> : IMonad<TOk>, IResult
{
    /// <summary>
    /// Returns the fail value of the Result. If the internal state is Ok, this will throw an exception
    /// </summary>
    TFail ReduceFail { get; }
    
    /// <summary>
    /// Returns the fail value of the Result, or an alternative supplied value
    /// </summary>
    TFail ReduceFailOr(TFail orValue);
    
    /// <summary>
    /// Returns the fail value of the Result, or an alternative value returned by the supplied function called lazily
    /// </summary>
    TFail ReduceFailOr(Func<TFail> orValueFn);
}

/// <summary>
/// Main result type implementation
/// </summary>
/// <typeparam name="TOk"></typeparam>
/// <typeparam name="TFail"></typeparam>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Result<TOk, TFail> : IResult<TOk, TFail>, IEquatable<Result<TOk, TFail>>, IEquatable<IMonad<TOk>>
{
    /// <inheritdoc />
    public bool HasValue { get; }

    /// <inheritdoc />
    public bool IsOk => HasValue;

    /// <inheritdoc />
    public bool IsFail => !HasValue;
    
    private readonly TOk _valueOk;
    private readonly TFail _valueFail;

    internal Result(bool hasValue, TOk valueOk, TFail valueFail)
    {
        HasValue = hasValue;
        if (hasValue)
        {
            _valueOk = valueOk ?? throw new InvalidOperationException("Ok value is null");
            _valueFail = default;
        }
        else
        {
            _valueFail = valueFail;
            _valueOk = default;
        }
    }

    /// <inheritdoc />
    public TOk Reduce => _valueOk;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOk ReduceOr(TOk orValue) => HasValue ? _valueOk : orValue;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TOk ReduceOr(Func<TOk> orValueFn) => HasValue ? _valueOk : orValueFn();

    /// <inheritdoc />
    public TFail ReduceFail => _valueFail;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TFail ReduceFailOr(TFail orValue) => IsFail ? _valueFail : orValue;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TFail ReduceFailOr(Func<TFail> orValueFn) => IsFail ? _valueFail : orValueFn();

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IMonad<U> Bind<U>(Func<TOk, IMonad<U>> bindFn) => HasValue ? bindFn(_valueOk) : new Result<U, TFail>(false, default, default);

    /// <inheritdoc />
    public bool Equals(Result<TOk, TFail> other)
        => HasValue == other.HasValue &&
           HasValue
            ? Nullable.Equals(_valueOk, other._valueOk)
            : Nullable.Equals(_valueFail, other._valueFail);

    /// <inheritdoc />
    public override bool Equals(object obj) 
        => obj is Result<TOk, TFail> other && Equals(other);

    /// <inheritdoc />
    public bool Equals(IMonad<TOk> monad) 
        => monad is Result<TOk, TFail> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() 
        => HasValue 
            ? HashCode.Combine(HasValue, _valueOk) 
            : HashCode.Combine(HasValue, _valueFail);

    public static bool operator ==(Result<TOk, TFail> left, Result<TOk, TFail> right) => left.Equals(right);

    public static bool operator !=(Result<TOk, TFail> left, Result<TOk, TFail> right) => !left.Equals(right);
    
    public static bool operator ==(Result<TOk, TFail> left, IMonad<TOk> right) => left.Equals(right);

    public static bool operator !=(Result<TOk, TFail> left, IMonad<TOk> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<TOk> left, Result<TOk, TFail> right) => right.Equals(left);

    public static bool operator !=(IMonad<TOk> left, Result<TOk, TFail> right) => !right.Equals(left);
}

/// <summary>
/// Result structure mainly for factory constructors
/// </summary>
public readonly struct Result
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Ok<TOk, TFail>(TOk value)
        => new (true, value, default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Fail<TOk, TFail>(TFail value)
        => new (false, default, value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, IFailure> Ok<TOk>(TOk value)
        => new (true, value, default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, IFailure> Fail<TOk>(IFailure value)
        => new (false, default, value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<Unit, IFailure> Fail(IFailure value)
        => new (false, Unit.Value, value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> From<TOk, TFail>(TOk valueOk, TFail valueFail)
        => valueOk == null ? new (false, default, valueFail) : new (true, valueOk, default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> From<TOk, TFail>(TOk valueOk, Func<TFail> valueFailFn)
        => valueOk == null ? new (false, default, valueFailFn()) : new (true, valueOk, default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> From<TOk, TFail>(Func<TOk> valueOkFn, Func<TFail> valueFailFn)
    {
        var valueOk = valueOkFn();
        return valueOk == null ? new(false, default, valueFailFn()) : new(true, valueOk, default);
    }
    
    public static Result<TReturn, TExn> Try<TReturn, TExn>(Func<TReturn> tryFn) where TExn : Exception
    {
        try
        {
            return Ok<TReturn, TExn>(tryFn());
        }
        catch (TExn e)
        {
            return Fail<TReturn, TExn>(e);
        }
    }
    
    public static Result<TReturn, TExn> Try<TParam, TReturn, TExn>(Func<TParam[], TReturn> tryFn, params TParam[] @params) where TExn : Exception
    {
        try
        {
            return Ok<TReturn, TExn>(tryFn(@params));
        }
        catch (TExn e)
        {
            return Fail<TReturn, TExn>(e);
        }
    }
    
    public static Result<Unit, TExn> Try<TParam, TReturn, TExn>(Action<TParam[]> tryAction, params TParam[] @params) where TExn : Exception
    {
        try
        {
            tryAction(@params);
            return Ok<Unit, TExn>(Unit.Value);
        }
        catch (TExn e)
        {
            return Fail<Unit, TExn>(e);
        }
    }
}