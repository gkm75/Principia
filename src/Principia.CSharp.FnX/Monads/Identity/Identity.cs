using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Principia.CSharp.FnX.Monads;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
public readonly struct Identity<T> : IMonad<T>, IEquatable<Identity<T>>, IEquatable<IMonad<T>>
{
    internal static Identity<T> Empty = new (false, default);
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

    public override string ToString() => $"|{_value}|";

    public bool Equals(Identity<T> other) 
        => HasValue && other.HasValue && Nullable.Equals(_value, other._value);

    public override bool Equals(object obj) 
        => obj is Identity<T> other && Equals(other);
    
    public bool Equals(IMonad<T> obj) 
        => obj is Identity<T> other && Equals(other);

    public override int GetHashCode() => HasValue ? _value.GetHashCode() : 0;

    public static bool operator ==(Identity<T> left, Identity<T> right) => left.Equals(right);

    public static bool operator !=(Identity<T> left, Identity<T> right) => !left.Equals(right);
    
    public static bool operator ==(Identity<T> left, IMonad<T> right) => left.Equals(right);

    public static bool operator !=(Identity<T> left, IMonad<T> right) => !left.Equals(right);
    
    public static bool operator ==(IMonad<T> left, Identity<T> right) => right.Equals(left);

    public static bool operator !=(IMonad<T> left, Identity<T> right) => !right.Equals(left);
    
    public static implicit operator Identity<T>(Identity<Unit> _) => Empty;
}

public readonly struct Identity
{
    public static Identity<Unit> EMPTY => Identity<Unit>.Empty;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> From<T>(T value) => Identity<T>.From(value);
}