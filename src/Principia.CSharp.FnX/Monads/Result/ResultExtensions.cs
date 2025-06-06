using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;

/// <summary>
/// Result-Type extension methods
/// </summary>
public static class ResultExtensions
{
    public static void Deconstruct<TOk, TFail>(this IResult<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ValueOr(default(TOk));
        fail = result.FailValueOr(default(TFail));
    }
    
    public static void Deconstruct<TOk, TFail>(this Result<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ValueOr(default(TOk));
        fail = result.FailValueOr(default(TFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TOk> ToEnumerable<TOk, TFail>(this Result<TOk, TFail> result)
        => result.IsOk ? new []{ result.Value } : Enumerable.Empty<TOk>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Map<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, TNewOk> mapFn)
        => result.IsOk 
            ? Result.From<TNewOk, TFail>(mapFn(result.Value), result.ValueFail) 
            : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Map<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, TNewOk> mapFn)
        => result.IsOk 
            ? Result.From<TNewOk, TFail>(mapFn(result), result.ValueFail) 
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> MapFail<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk> mapFn)
        => result.IsFail ? Result.From(mapFn(), result.ValueFail) : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Bind<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TNewOk, TFail>> bindFn)
        => result.IsOk ? bindFn(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Bind<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Result<TNewOk, TFail>> bindFn)
        => result.IsOk ? bindFn(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> BindFail<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>> bindFn)
        => result.IsFail ? bindFn() : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Join<TOk, TFail>(this Result<Result<TOk, TFail>, TFail> result)
        => result.IsOk ? result.Value : Result.Fail<TOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Filter<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, bool> predicate)
        => result.IsOk && predicate(result.Value) 
            ? result 
            : result.IsFail 
                ? result 
                : Result.Fail<TOk,TFail>(default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action action)
    {
        if (result.IsOk)
        {
            action();
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action action)
    {
        if (result.IsFail)
        {
            action();
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action<TOk> action)
    {
        if (result.IsOk)
        {
            action(result.Value);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action<TFail> action)
    {
        if (result.IsFail)
        {
            action(result.ValueFail);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> action)
    {
        if (result.IsOk)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> action)
    {
        if (result.IsFail)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Or<TOk, TFail>(this Result<TOk, TFail> result, Result<TOk, TFail> fallback)
        => result.IsFail ? fallback : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Or<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>> fallbackFn)
        => result.IsFail ? fallbackFn() : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Or<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk> okFn)
        => result.IsFail ? Result.Ok<TOk, TFail>(okFn()) : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Or<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk> okFn, Func<TFail> failFn)
        => result.IsFail ? Result.From<TOk, TFail>(okFn(), failFn) : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, TNewOk>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? Result.Ok<TNewOk, TFail>(resultFn.Value(result.Value)) 
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, Result<TNewOk, TFail>>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? resultFn.Value(result.Value) 
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<Result<TOk, TFail>, Result<TNewOk, TFail>>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? resultFn.Value(result) 
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Combine<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<TOkLt, TOkRt, TNewOk> combineFn)
        => resultLt.IsOk && resultRt.IsOk 
            ? Result.Ok<TNewOk, TFail>(combineFn(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Combine<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Result<TNewOk, TFail>> combineFn)
        => resultLt.IsOk && resultRt.IsOk 
            ? combineFn(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
}
