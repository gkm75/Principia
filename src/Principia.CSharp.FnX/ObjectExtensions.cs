using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Principia.CSharp.FnX.Monads;

namespace Principia.CSharp.FnX;

/// <summary>
/// Convenient Object extensions for functional style C#
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// General Map/Converting function that is available to all objects 
    /// </summary>
    /// <param name="obj">The object instance</param>
    /// <param name="mapFn">The mapping function</param>
    /// <typeparam name="T">The original type of the passed object</typeparam>
    /// <typeparam name="TReturn">The return type of the mapping function</typeparam>
    /// <returns>The transformed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TReturn Map<T, TReturn>(this T obj, Func<T, TReturn> mapFn) => mapFn(obj);
    
    /// <summary>
    /// Performs a deep copy of the passed object instance through Json serialization
    /// </summary>
    /// <param name="obj">The object instance to copy</param>
    /// <typeparam name="T">The type of the passed instance</typeparam>
    /// <returns>A deep copy of the passed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeepClone<T>(this T obj)
    {
        if (ReferenceEquals(obj, null))
        {
            return default;
        }
        
        var serialized = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(serialized);
    }
    
    /// <summary>
    /// Accepts an object instance and a transforming function and returns a new function with no parameters which
    /// applies the object lazily to the transforming function
    /// </summary>
    /// <param name="left">The object instance</param>
    /// <param name="rightFn">The transforming function</param>
    /// <typeparam name="T">The type of the converted result</typeparam>
    /// <returns>A function which transforms the object instance via the transforming function</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<T> Pipe<T>(this object left, Func<object, T> rightFn)
        => () => rightFn(left);

    /// <summary>
    /// Converts the passed object to an Option type
    /// </summary>
    /// <param name="obj">The instance</param>
    /// <typeparam name="T">The type of the object instance</typeparam>
    /// <returns>An option out of the passed object/returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> ToOption<T>(this T obj) => Option.From(obj);
    
    /// <summary>
    /// Converts the passed object to a Result type
    /// </summary>
    /// <param name="obj">The object instance</param>
    /// <param name="otherwise">A TFail instance object to represent the fail case</param>
    /// <typeparam name="TOk">The Ok case type</typeparam>
    /// <typeparam name="TFail">The Fail case type</typeparam>
    /// <returns>A result type out of the passed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> ToResult<TOk, TFail>(this TOk obj, TFail otherwise) 
        => Result.From(obj, otherwise);

    /// <summary>
    /// Converts the passed object to a Result type
    /// </summary>
    /// <param name="obj">The object instance</param>
    /// <param name="fail">A fail object impementing the IFailure market interface</param>
    /// <typeparam name="TOk">The Ok case type</typeparam>
    /// <returns>A result type out of the passed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, IFailure> ToResult<TOk>(this TOk obj, IFailure fail = default)
        => obj != null ? Result.Ok(obj) : Result.Fail<TOk, IFailure>(fail);
    
    /// <summary>
    /// Converts the passed object to a Result type
    /// </summary>
    /// <param name="obj">The object instance</param>
    /// <param name="otherwiseFn">Function to create the fail object called lazily</param>
    /// <typeparam name="TOk">The Ok case type</typeparam>
    /// <typeparam name="TFail">The Fail case type</typeparam>
    /// <returns>A result type out of the passed object</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> ToResult<TOk, TFail>(this TOk obj, Func<TFail> otherwiseFn) 
        => Result.From(obj, otherwiseFn);
}