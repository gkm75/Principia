using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// Identity monad extension methods
/// </summary>
public static class IdentityExtensions
{
    /// <summary>
    /// Returns an enumerable out of the Identity, if there is no value then the empty enumerable is returned
    /// </summary>
    /// <param name="identity">The identity instance</param>
    /// <typeparam name="T">The type of the instance wrapped by the Identity monad</typeparam>
    /// <returns>IEnumerable of T</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ToEnumerable<T>(this Identity<T> identity)
        => identity.HasValue ? new []{ identity.Reduce } : Enumerable.Empty<T>();
    
    /// <summary>
    /// Transforms the Identity monad into another Identity wrapping a different type
    /// </summary>
    /// <param name="identity">The identity instance</param>
    /// <param name="mapFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<U> Map<T, U>(this Identity<T> identity, Func<T, U> mapFn)
        =>  Identity<U>.From(identity.HasValue ? mapFn(identity.Reduce) : default);
 
    /// <summary>
    /// 
    /// </summary>
    /// <param name="identity">The identity instance</param>
    /// <param name="bindFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<U> Bind<T, U>(this Identity<T> identity, Func<T, Identity<U>> bindFn)
        => identity.HasValue ? bindFn(identity.Reduce) : Identity.EMPTY;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="identity">The identity instance</param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> Filter<T>(this Identity<T> identity, Func<T, bool> predicate)
        => identity.HasValue && predicate(identity.Reduce) ? identity : Identity.EMPTY;
    
    /// <summary>
    /// Flattening operation, transforms (Identity of (Identity of T)) into an Identity of T
    /// </summary>
    /// <param name="identity">The identity instance</param>
    /// <typeparam name="T">The type of the inner Identity</typeparam>
    /// <returns>The flattened Identity</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Identity<T> Join<T>(this Identity<Identity<T>> identity)
        => identity.HasValue ? identity.Reduce : Identity.EMPTY;
}