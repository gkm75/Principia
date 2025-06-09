using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Principia.CSharp.FnX.Monads;

public static class IdentityAsyncExtensions
{
    /// <summary>
    /// Returns an enumerable out of the Identity, if there is no value then the empty enumerable is returned
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <typeparam name="T">The type of the instance wrapped by the Identity monad</typeparam>
    /// <returns>IEnumerable of T</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<IEnumerable<T>> ToEnumerableAsync<T>(this Task<Identity<T>> identityTask)
    {
        var identity = await identityTask;
        return identity.HasValue ? new[] {identity.Value} : Enumerable.Empty<T>();
    }

    /// <summary>
    /// Transforms the Identity monad into another Identity wrapping a different type
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <param name="mapFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Identity<U>> MapAsync<T, U>(this Task<Identity<T>> identityTask, Func<T, U> mapFn)
    {
        var identity = await identityTask;
        return Identity<U>.From(mapFn(identity.Value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <param name="bindFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Identity<U>> BindAsync<T, U>(this Task<Identity<T>> identityTask, Func<T, Identity<U>> bindFn)
    {
        var identity = await identityTask;
        return bindFn(identity.Value);
    }

    /// <summary>
    /// Flattening operation, transforms (Identity of (Identity of T)) into an Identity of T
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <typeparam name="T">The type of the inner Identity</typeparam>
    /// <returns>The flattened Identity</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Identity<T>> JoinAsync<T>(this Task<Identity<Identity<T>>> identityTask)
    {
        var identity = await identityTask;
        return identity.Value;
    }

    /// <summary>
    /// Apply function accepts a wrapped function which called with the identity value as actual parameter 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="fn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public static async Task<Identity<U>> ApplyAsync<T, U>(this Task<Identity<T>> identityTask, Identity<Func<T, U>> fn)
    {
        var identity = await identityTask;
        return Identity.From(fn.Value(identity.Value));
    }

    /// <summary>
    /// Combined two identity monads using the supplied function 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="identity2"></param>
    /// <param name="combineFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Identity<V>> CombineAsync<T, U, V>(this Task<Identity<T>> identityTask, Identity<U> identity2, Func<T, U, V> combineFn)
    {
        var identity = await identityTask;
        return Identity.From(combineFn(identity.Value, identity2.Value));
    }

    /// <summary>
    /// Combined two identity monads using the supplied function 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="identity2Task"></param>
    /// <param name="combineFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Identity<V>> CombineAsync<T, U, V>(this Task<Identity<T>> identityTask, Task<Identity<U>> identity2Task, Func<T, U, V> combineFn)
    {
        var identity = await identityTask;
        var identity2 = await identity2Task;
        return Identity.From(combineFn(identity.Value, identity2.Value));
    }
}


public static class IdentityValueAsyncExtensions
{
    /// <summary>
    /// Returns an enumerable out of the Identity, if there is no value then the empty enumerable is returned
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <typeparam name="T">The type of the instance wrapped by the Identity monad</typeparam>
    /// <returns>IEnumerable of T</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<IEnumerable<T>> ToEnumerableValueAsync<T>(this ValueTask<Identity<T>> identityTask)
    {
        var identity = await identityTask;
        return identity.HasValue ? new[] {identity.Value} : Enumerable.Empty<T>();
    }

    /// <summary>
    /// Transforms the Identity monad into another Identity wrapping a different type
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <param name="mapFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Identity<U>> MapValueAsync<T, U>(this ValueTask<Identity<T>> identityTask, Func<T, U> mapFn)
    {
        var identity = await identityTask;
        return Identity<U>.From(mapFn(identity.Value));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <param name="bindFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Identity<U>> BindValueAsync<T, U>(this ValueTask<Identity<T>> identityTask, Func<T, Identity<U>> bindFn)
    {
        var identity = await identityTask;
        return bindFn(identity.Value);
    }

    /// <summary>
    /// Flattening operation, transforms (Identity of (Identity of T)) into an Identity of T
    /// </summary>
    /// <param name="identityTask">The identity instance</param>
    /// <typeparam name="T">The type of the inner Identity</typeparam>
    /// <returns>The flattened Identity</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Identity<T>> JoinValueAsync<T>(this ValueTask<Identity<Identity<T>>> identityTask)
    {
        var identity = await identityTask;
        return identity.Value;
    }

    /// <summary>
    /// Apply function accepts a wrapped function which called with the identity value as actual parameter 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="fn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <returns></returns>
    public static async ValueTask<Identity<U>> ApplyValueAsync<T, U>(this ValueTask<Identity<T>> identityTask, Identity<Func<T, U>> fn)
    {
        var identity = await identityTask;
        return Identity.From(fn.Value(identity.Value));
    }

    /// <summary>
    /// Combined two identity monads using the supplied function 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="identity2"></param>
    /// <param name="combineFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Identity<V>> CombineValueAsync<T, U, V>(this ValueTask<Identity<T>> identityTask, Identity<U> identity2, Func<T, U, V> combineFn)
    {
        var identity = await identityTask;
        return Identity.From(combineFn(identity.Value, identity2.Value));
    }

    /// <summary>
    /// Combined two identity monads using the supplied function 
    /// </summary>
    /// <param name="identityTask"></param>
    /// <param name="identity2Task"></param>
    /// <param name="combineFn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Identity<V>> CombineValueAsync<T, U, V>(this ValueTask<Identity<T>> identityTask, ValueTask<Identity<U>> identity2Task, Func<T, U, V> combineFn)
    {
        var identity = await identityTask;
        var identity2 = await identity2Task;
        return Identity.From(combineFn(identity.Value, identity2.Value));
    }
}