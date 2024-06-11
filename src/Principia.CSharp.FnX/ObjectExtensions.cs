using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Principia.CSharp.FnX.Monads;

namespace Principia.CSharp.FnX;

public static class ObjectExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TReturn Map<T, TReturn>(this T obj, Func<T, TReturn> mapFn) => mapFn(obj);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeepClone<T>(this T obj)
    {
        var serialized = JsonSerializer.Serialize(obj);
        return JsonSerializer.Deserialize<T>(serialized);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<T> Pipe<T>(this object left, Func<object, T> rightFn)
        => () => rightFn(left);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> ToOption<T>(this T obj) => Option.From(obj);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> ToResult<TOk, TFail>(this TOk obj, TFail otherwise) 
        => Result.From(obj, otherwise);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> ToResult<TOk, TFail>(this TOk obj, Func<TFail> otherwiseFn) 
        => Result.From(obj, otherwiseFn);
}