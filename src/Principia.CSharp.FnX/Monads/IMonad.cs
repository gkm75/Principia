using System;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// Base interface for the monadic structures
/// </summary>
public interface IMonad
{
    /// <summary>
    /// Indicates if the Monad is wrapping an instance or not
    /// </summary>
    bool HasValue { get; }
}

/// <summary>
/// Base templated interface for the monadic structures
/// </summary>
/// <typeparam name="T">The type of the wrapped instance</typeparam>
public interface IMonad<T> : IMonad
{
    /// <summary>
    /// Returns the underlying wrapped instance
    /// </summary>
    T Reduce { get; }
    
    /// <summary>
    /// Returns the underlying wrapped instance if present or the alternative orValue
    /// </summary>
    /// <param name="orValue">The alternative orValue</param>
    /// <returns>An instance of type T</returns>
    T ReduceOr(T orValue);
    
    /// <summary>
    /// Returns the underlying wrapped instance if present or the alternative orValue evaluated lazily
    /// </summary>
    /// <param name="orValueFn">The function which supplies an alternative orValue</param>
    /// <returns>An instance of type T</returns>
    T ReduceOr(Func<T> orValueFn);
    
    /// <summary>
    /// The Bind operation which transforms the current monad(T) into another monad(U), provided the source monad
    /// contains a value.
    /// </summary>
    /// <param name="bindFn">The transforming function</param>
    /// <typeparam name="U">The target instance type</typeparam>
    /// <returns>A new monad possibly wrapping a type U instance</returns>
    IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn);
}

