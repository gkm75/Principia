using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Principia.CSharp.FnX.Monads;

public interface IOption : IMonad
{
    bool IsSome { get; }
    bool IsNone { get; }
}

public interface IOption<T> : IMonad<T>, IOption;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Option<T> : IOption<T>, IEquatable<Option<T>>, IEquatable<IMonad<T>>
{
    internal static Option<T> None = new(false, default);
    public bool HasValue { get; }
    private readonly T _value;
    
    public bool IsSome => HasValue;
    
    public bool IsNone => !HasValue;
    
    internal Option(bool hasValue, T value)
    {
        HasValue = hasValue;
        if (hasValue)
        {
            _value = value ?? throw new InvalidOperationException("Some value cannot be null");
        }
    }

    public T Reduce => _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(T orValue) => HasValue ? _value : orValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(Func<T> orValueFn) => HasValue ? _value : orValueFn();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn) => HasValue ? bindFn(_value) : Option<U>.None;

    public override string ToString()
        => IsSome ? $"Some {_value}" : $"None<{typeof(T).Name}>";

    public bool Equals(Option<T> other) => IsNone && other.IsNone || Nullable.Equals(_value, other._value);

    public override bool Equals(object obj) => obj is Option<T> other && Equals(other);
    
    public bool Equals(IMonad<T> monad) => monad is Option<T> other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(HasValue, _value);

    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, Option<T> right) => !left.Equals(right);
    
    public static bool operator ==(Option<T> left, IMonad<T> right) => left.Equals(right);

    public static bool operator !=(Option<T> left, IMonad<T> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<T> left, Option<T> right) => right.Equals(left);

    public static bool operator !=(IMonad<T> left, Option<T> right) => !right.Equals(left);

    public static implicit operator Option<T>(Option<Unit> _) => None;
}

public readonly struct Option
{
    public static Option<Unit> NONE => Option<Unit>.None;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Some<T>(T value)
        => new (true, value);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> None<T>()
        => new (false, default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> From<T>(T value)
        => value != null ? Some(value) : None<T>();

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