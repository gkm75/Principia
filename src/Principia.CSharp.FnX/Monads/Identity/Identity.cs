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
    internal static Identity<T> Empty = new (false, default);
    
    /// <inheritdoc />
    public bool HasValue { get; }
    private readonly T _value;
    
    private Identity(bool hasValue, T value)
    {
        HasValue = hasValue;
        _value = hasValue ? value : default;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> From(T value) => new (value != null, value);
    
    
    public T Reduce 
        => HasValue ? _value : throw new InvalidOperationException("Identity has no value");
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(T orValue)
        => HasValue ? _value : orValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T ReduceOr(Func<T> orValueFn)
        => HasValue ? _value : orValueFn();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn)
        => HasValue ? bindFn(Reduce) : Identity<U>.From(default);

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
    public override int GetHashCode() => HasValue ? _value.GetHashCode() : 0;
    
    public static bool operator ==(Identity<T> left, Identity<T> right) => left.Equals(right);
    
    public static bool operator !=(Identity<T> left, Identity<T> right) => !left.Equals(right);
    
    public static bool operator ==(Identity<T> left, IMonad<T> right) => left.Equals(right);

    public static bool operator !=(Identity<T> left, IMonad<T> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<T> left, Identity<T> right) => right.Equals(left);

    public static bool operator !=(IMonad<T> left, Identity<T> right) => !right.Equals(left);
    
    /// <summary>
    /// Implicit cast to turn an Identity of Unit instance into Empty
    /// </summary>
    /// <param name="_">Identity of Unit instance</param>
    /// <returns>Empty Identity instance</returns>
    public static implicit operator Identity<T>(Identity<Unit> _) => Empty;
}

/// <summary>
/// Identity structure mainly containing the factory method
/// </summary>
public readonly struct Identity
{
    /// <summary>
    /// Generic property representing an Empty Identity monad
    /// </summary>
    public static Identity<Unit> EMPTY => Identity<Unit>.Empty;
    
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