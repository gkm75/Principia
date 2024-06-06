using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX;

public static partial class Function
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Pipe<T, U>(this T left, Func<T, U> rightFn)
        => () => rightFn(left);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Pipe<T, U>(this Func<T> leftFn, Func<T, U> rightFn)
        => () => rightFn(leftFn());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<T, V> Pipe<T, U, V>(this Func<T, U> leftFn, Func<U, V> rightFn)
        => (T param) => rightFn(leftFn(param));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Compose<V, U>(this Func<V, U> leftFn, Func<V> rightFn)
        => () => leftFn(rightFn());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U, T> Compose<V, U, T>(this Func<V, T> leftFn, Func<U, V> rightFn)
        => (U param) => leftFn(rightFn(param));
}
