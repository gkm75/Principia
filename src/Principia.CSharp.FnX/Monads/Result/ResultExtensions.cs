using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;

public static class ResultExtensions
{
    public static void Deconstruct<TOk, TFail>(this IResult<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ReduceOr(default(TOk));
        fail = result.ReduceFailOr(default(TFail));
    }
    
    public static void Deconstruct<TOk, TFail>(this Result<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ReduceOr(default(TOk));
        fail = result.ReduceFailOr(default(TFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Map<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, TNewOk> mapFn)
        => result.IsOk 
            ? Result.From<TNewOk, TFail>(mapFn(result.Reduce), result.ReduceFail) 
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Map<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, TNewOk> mapFn)
        => result.IsOk 
            ? Result.From<TNewOk, TFail>(mapFn(result), result.ReduceFail) 
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> MapFail<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk> mapFn)
        => result.IsFail ? Result.From(mapFn(), result.ReduceFail) : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Bind<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TNewOk, TFail>> bindFn)
        => result.IsOk ? bindFn(result.Reduce) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Bind<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Result<TNewOk, TFail>> bindFn)
        => result.IsOk ? bindFn(result) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> BindFail<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>> bindFn)
        => result.IsFail ? bindFn() : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Join<TOk, TFail>(this Result<Result<TOk, TFail>, TFail> result)
        => result.IsOk ? result.Reduce : Result.Fail<TOk, TFail>(result.ReduceFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> Filter<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, bool> predicate)
        => result.IsOk && predicate(result.Reduce) 
            ? result 
            : result.IsFail 
                ? result 
                : Result.Fail<TOk,TFail>(default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action<TOk> action)
    {
        if (result.IsOk)
        {
            action(result.Reduce);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action<TFail> action)
    {
        if (result.IsFail)
        {
            action(result.ReduceFail);
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
    public static void Match<TOk, TFail>(this Result<TOk, TFail> result, Action<TOk> okAction, Action<TFail> failAction)
    {
        if (result.IsOk)
        {
            okAction(result.Reduce);
        }
        else
        {
            failAction(result.ReduceFail);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Match<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> okAction, Action<Result<TOk, TFail>> failAction)
    {
        if (result.IsOk)
        {
            okAction(result);
        }
        else
        {
            failAction(result);
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TNewOk Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, TNewOk ok, TNewOk fail)
        => result.IsOk ? ok : fail;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TNewOk Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TNewOk> okFn, Func<TNewOk> failFn)
        => result.IsOk ? okFn() : failFn();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TNewOk, TFail>> okFn, Func<Result<TNewOk, TFail>> failFn)
        => result.IsOk ? okFn() : failFn();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TNewOk, TFail>> okFn, TNewOk fail)
        => result.IsOk ? okFn() : Result.Ok<TNewOk, TFail>(fail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, TNewOk ok, Func<Result<TNewOk, TFail>> failFn)
        => result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : failFn();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TNewOk> okFn, TNewOk fail)
        => result.IsOk ? Result.Ok<TNewOk, TFail>(okFn()) : Result.Ok<TNewOk, TFail>(fail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Match<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, TNewOk ok, Func<TNewOk> failFn)
        => result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : Result.Ok<TNewOk, TFail>(failFn());
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, TNewOk>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? Result.Ok<TNewOk, TFail>(resultFn.Reduce(result.Reduce)) 
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, Result<TNewOk, TFail>>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? resultFn.Reduce(result.Reduce) 
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Apply<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<Result<TOk, TFail>, Result<TNewOk, TFail>>, TFail> resultFn)
        => result.IsOk && resultFn.IsOk 
            ? resultFn.Reduce(result) 
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Combine<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<TOkLt, TOkRt, TNewOk> combineFn)
        => resultLt.IsOk && resultRt.IsOk 
            ? Result.Ok<TNewOk, TFail>(combineFn(resultLt.Reduce, resultRt.Reduce))
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Result<TNewOk, TFail> Combine<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Result<TNewOk, TFail>> combineFn)
        => resultLt.IsOk && resultRt.IsOk 
            ? combineFn(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
}
