using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// Base interface for all Option type monads
/// </summary>
public interface IOption : IMonad
{
    /// <summary>
    /// Property to indicate if the option wraps a value
    /// </summary>
    bool IsSome { get; }
    
    /// <summary>
    /// Property to indicate if the option does not wrap a value
    /// </summary>
    bool IsNone { get; }
}

/// <summary>
/// Base interface for generic type options
/// </summary>
/// <typeparam name="T">The type of the wrapped instance</typeparam>
public interface IOption<T> : IMonad<T>, IOption;

/// <summary>
/// Main Option monad implementation
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Option<T> : IOption<T>, IEquatable<Option<T>>, IEquatable<IMonad<T>>
{
    internal static Option<T> None = new(false, default);
    
    /// <inheritdoc />
    public bool HasValue { get; }
    private readonly T _value;
    
    /// <inheritdoc />
    public bool IsSome => HasValue;
    
    /// <inheritdoc />
    public bool IsNone => !HasValue;
    
    internal Option(bool hasValue, T value)
    {
        HasValue = hasValue;
        if (hasValue)
        {
            _value = value ?? throw new InvalidOperationException("Some value cannot be null");
        }
    }

    /// <inheritdoc />
    public T Reduce => _value;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(T orValue) => HasValue ? _value : orValue;

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(Func<T> orValueFn) => HasValue ? _value : orValueFn();

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn) => HasValue ? bindFn(_value) : Option<U>.None;

    /// <inheritdoc />
    public override string ToString()
        => IsSome ? $"Some {_value}" : $"None<{typeof(T).Name}>";

    /// <inheritdoc />
    public bool Equals(Option<T> other) => IsNone && other.IsNone || Nullable.Equals(_value, other._value);

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is Option<T> other && Equals(other);
    
    /// <inheritdoc />
    public bool Equals(IMonad<T> monad) => monad is Option<T> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => HashCode.Combine(HasValue, _value);

    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, Option<T> right) => !left.Equals(right);
    
    public static bool operator ==(Option<T> left, IMonad<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, IMonad<T> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<T> left, Option<T> right) => right.Equals(left);

    public static bool operator !=(IMonad<T> left, Option<T> right) => !right.Equals(left);

    /// <summary>
    /// Implicit cast operator from a generic None into a templated Option none
    /// </summary>
    /// <param name="_"></param>
    /// <returns>None</returns>
    public static implicit operator Option<T>(Option<Unit> _) => None;
}

/// <summary>
/// Option struct acts as a module to expose extension methods
/// </summary>
public readonly struct Option
{
    /// <summary>
    /// General None value
    /// </summary>
    public static Option<Unit> NONE => Option<Unit>.None;

    /// <summary>
    /// Option Some constructor, creates a Some from the passed value
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Some</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Some<T>(T value)
        => new (true, value);
    
    /// <summary>
    /// Option None constructor, creates a None from the Template parameter
    /// </summary>
    /// <typeparam name="T">The type of the wrapped instance</typeparam>
    /// <returns>None</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> None<T>()
        => new (false, default);

    /// <summary>
    /// Returns an Option type out of the passed value, Some or None depending on the instance passed
    /// </summary>
    /// <param name="value">Value to be wrapped in the option</param>
    /// <typeparam name="T">The type of the wrapped instance</typeparam>
    /// <returns>Option</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> From<T>(T value)
        => value != null ? Some(value) : None<T>();

    /// <summary>
    /// Tries to execute a function and returns an Option. If an exception occurs then a None option is returned
    /// </summary>
    /// <param name="tryFn"></param>
    /// <typeparam name="TReturn"></typeparam>
    /// <typeparam name="TExn"></typeparam>
    /// <returns></returns>
    public static Option<TReturn> Try<TReturn, TExn>(Func<TReturn> tryFn) where TExn : Exception
    {
        try
        {
            return Some(tryFn());
        }
        catch (TExn e)
        {
            return None<TReturn>();
        }
    }
    
    /// <summary>
    /// Tries to execute a function and returns an Option. If an exception occurs then a None option is returned
    /// </summary>
    /// <param name="tryFn"></param>
    /// <param name="params"></param>
    /// <typeparam name="TParam"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <typeparam name="TExn"></typeparam>
    /// <returns></returns>
    public static Option<TReturn> Try<TParam, TReturn, TExn>(Func<TParam[], TReturn> tryFn, params TParam[] @params) where TExn : Exception
    {
        try
        {
            return Some(tryFn(@params));
        }
        catch (TExn e)
        {
            return None<TReturn>();
        }
    }
    
    /// <summary>
    /// Tries to execute an action and returns an Option. If an exception occurs then a None option is returned
    /// </summary>
    /// <param name="tryAction"></param>
    /// <param name="params"></param>
    /// <typeparam name="TParam"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <typeparam name="TExn"></typeparam>
    /// <returns></returns>
    public static Option<Unit> Try<TParam, TReturn, TExn>(Action<TParam[]> tryAction, params TParam[] @params) where TExn : Exception
    {
        try
        {
            tryAction(@params);
            return Some(Unit.Value);
        }
        catch (TExn e)
        {
            return None<Unit>();
        }
    }
}