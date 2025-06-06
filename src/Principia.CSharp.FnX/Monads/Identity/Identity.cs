using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// The Identity monad which merely wraps an object. Not a very useful class but it's here for completeness.
/// </summary>
/// <typeparam name="T">Type of the wrapped object</typeparam>
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Identity<T> : IMonad<T>, IEquatable<Identity<T>>, IEquatable<IMonad<T>>
{
    /// <inheritdoc />
    public bool HasValue => true;
    private readonly T _value;
    
    private Identity(T value)
    {
        _value = value ?? throw new InvalidOperationException("Identity has no value");
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> From(T value) => new (value);
    
    public T Value => _value;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ValueOr(T _) => _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ValueOr(Func<T> orValueFn) => _value;

    /// <inheritdoc />
    public Identity<T> EnsureIdentity() 
        => this;

    /// <inheritdoc />
    public Option<T> EnsureOption() 
        => HasValue ? Option.Some(_value) : Option<T>.None;
    
    /// <inheritdoc />
    public Result<T, TFail> EnsureResult<TFail>(TFail failValue)
        => HasValue ? Result.Ok<T, TFail>(_value) : Result.Fail<T, TFail>(failValue);

    /// <inheritdoc />
    public Result<T, TFail> EnsureResult<TFail>(Func<TFail> failFn)
        => HasValue ? Result.Ok<T, TFail>(_value) : Result.Fail<T, TFail>(failFn());
    
    /// <summary>
    /// ToString overload returning the string representation of the Identity instance
    /// </summary>
    /// <returns>string</returns>
    public override string ToString() => $"|{_value}|";

    /// <inheritdoc />
    public bool Equals(Identity<T> other) 
        => HasValue && other.HasValue && Nullable.Equals(_value, other._value);

    /// <inheritdoc />
    public override bool Equals(object obj) 
        => obj is Identity<T> other && Equals(other);
    
    /// <inheritdoc />
    public bool Equals(IMonad<T> obj) 
        => obj is Identity<T> other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => _value.GetHashCode();
    
    public static bool operator ==(Identity<T> left, Identity<T> right) => left.Equals(right);
    
    public static bool operator !=(Identity<T> left, Identity<T> right) => !left.Equals(right);
    
    public static bool operator ==(Identity<T> left, IMonad<T> right) => left.Equals(right);

    public static bool operator !=(Identity<T> left, IMonad<T> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<T> left, Identity<T> right) => right.Equals(left);

    public static bool operator !=(IMonad<T> left, Identity<T> right) => !right.Equals(left);
}

/// <summary>
/// Identity structure mainly containing the factory method
/// </summary>
public readonly struct Identity
{
    /// <summary>
    /// Accepts an object instance and wraps it in an Identity monad. If the instance is null then the empty
    /// Identity is returned
    /// </summary>
    /// <param name="value">Instance to be wrapped</param>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <returns>An Identity instance</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> From<T>(T value) => Identity<T>.From(value);
}