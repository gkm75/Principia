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
    T Value { get; }
    
    /// <summary>
    /// Returns the underlying wrapped instance if present or the alternative orValue
    /// </summary>
    /// <param name="orValue">The alternative orValue</param>
    /// <returns>An instance of type T</returns>
    T ValueOr(T orValue);
    
    /// <summary>
    /// Returns the underlying wrapped instance if present or the alternative orValue evaluated lazily
    /// </summary>
    /// <param name="orValueFn">The function which supplies an alternative orValue</param>
    /// <returns>An instance of type T</returns>
    T ValueOr(Func<T> orValueFn);
    
    /// <summary>
    /// Transforms the underlying monad into an Identity monad if it contains a value. If it is already an
    /// Identity Monad, then the same instance is returned.
    /// </summary>
    /// <returns>Identity&lt;T&gt;</returns>
    Identity<T> EnsureIdentity();
    
    /// <summary>
    /// Transforms the underlying monad into an Option monad if it contains a value. If it is already an
    /// Option Monad, then the same instance is returned.
    /// </summary>
    /// <returns></returns>
    Option<T> EnsureOption();
    
    /// <summary>
    /// Transforms the underlying monad into a Result monad if it contains a value. If not, then the passed
    /// failValue will be used to construct the Fail instance which is returned.
    /// </summary>
    /// <param name="failValue"></param>
    /// <typeparam name="TFail"></typeparam>
    /// <returns></returns>
    Result<T, TFail> EnsureResult<TFail>(TFail failValue);
    
    /// <summary>
    /// Transforms the underlying monad into a Result monad if it contains a value. If not, then the passed
    /// failFn is executed to yield the value used to construct the Fail instance which is returned. 
    /// </summary>
    /// <param name="failFn"></param>
    /// <typeparam name="TFail"></typeparam>
    /// <returns></returns>
    Result<T, TFail> EnsureResult<TFail>(Func<TFail> failFn);
}

