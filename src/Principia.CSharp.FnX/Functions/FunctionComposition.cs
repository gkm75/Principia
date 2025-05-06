using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Functions;

/// <summary>
/// Extension methods transforming and operating on functions
/// </summary>
public static partial class Function
{
    /// <summary>
    /// Accepts a value and a transforming function add creates a new function without parameter and which calls the
    /// passed function applied to the passed value
    /// </summary>
    /// <param name="left">The value on which the function is applied</param>
    /// <param name="rightFn">The transforming function</param>
    /// <typeparam name="T">The type of the passed value and of the transforming function's parameter</typeparam>
    /// <typeparam name="U">The type of the return value</typeparam>
    /// <returns>A parameterless function which calls the passed function</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Pipe<T, U>(this T left, Func<T, U> rightFn)
        => () => rightFn(left);

    /// <summary>
    /// Composition of two functions, not in the mathematical sense, the output of one function is passed as input
    /// to the next function
    /// </summary>
    /// <param name="leftFn"></param>
    /// <param name="rightFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns>A function which calls the composition of the passed functions</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Pipe<T, U>(this Func<T> leftFn, Func<T, U> rightFn)
        => () => rightFn(leftFn());

    /// <summary>
    /// Composition of two functions, not in the mathematical sense, the output of one function is passed as input
    /// to the next function
    /// </summary>
    /// <param name="leftFn"></param>
    /// <param name="rightFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns>A function which calls the composition of the passed functions</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<T, V> Pipe<T, U, V>(this Func<T, U> leftFn, Func<U, V> rightFn)
        => (T param) => rightFn(leftFn(param));

    /// <summary>
    /// Composition of two functions, in the mathematical sense, the output of one function is passed as input
    /// to the next function
    /// </summary>
    /// <param name="leftFn"></param>
    /// <param name="rightFn"></param>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns>A function which calls the composition of the passed functions</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U> Compose<V, U>(this Func<V, U> leftFn, Func<V> rightFn)
        => () => leftFn(rightFn());

    /// <summary>
    /// Composition of two functions, in the mathematical sense, the output of one function is passed as input
    /// to the next function
    /// </summary>
    /// <param name="leftFn"></param>
    /// <param name="rightFn"></param>
    /// <typeparam name="V"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns>A function which calls the composition of the passed functions</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<U, T> Compose<V, U, T>(this Func<V, T> leftFn, Func<U, V> rightFn)
        => (U param) => leftFn(rightFn(param));
}
