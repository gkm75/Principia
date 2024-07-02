using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Principia.CSharp.FnX.Monads;

public static class ResultAsyncExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result.Reduce), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Reduce), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Reduce), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, ValueTask<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, ValueTask<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ReduceFail)
            : Result.Fail<TNewOk, TFail>(result.ReduceFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk> mapFn)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(mapFn(), result.ReduceFail) : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<TOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(await mapFnAsync(), result.ReduceFail) : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<TOk>> mapFnAsync) 
        => result.IsFail ? Result.From(await mapFnAsync(), result.ReduceFail) : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result.Reduce) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result.Reduce) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result.Reduce) : Result.Fail<TNewOk, TFail>(result.ReduceFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ReduceFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsFail ? bindFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await bindFnAsync() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TOk, TFail>>> bindFnAsync) 
        => result.IsFail ? await bindFnAsync() : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> JoinAsync<TOk, TFail>(this ValueTask<Result<Result<TOk, TFail>, TFail>> resultTask)
    {
        var result = await resultTask;
        return result.IsOk ? result.Reduce : Result.Fail<TOk, TFail>(result.ReduceFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> JoinAsync<TOk, TFail>(this Result<ValueTask<Result<TOk, TFail>>, TFail> result)
    {
        return result.IsOk ? await result.Reduce : Result.Fail<TOk, TFail>(result.ReduceFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, bool> predicate)
    {
        var result = await resultTask;
        return result.IsOk && predicate(result.Reduce)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<bool>> predicateAsync)
    {
        var result = await resultTask;
        return result.IsOk && await predicateAsync(result.Reduce)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<bool>> predicateAsync)
        => result.IsOk && await predicateAsync(result.Reduce)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<TOk> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result.Reduce);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<TFail> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result.ReduceFail);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<TOk, TFail> fallback)
    {
        var result = await resultTask;
        return result.IsFail ? fallback : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask,  ValueTask<Result<TOk, TFail>> fallbackAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackAsync : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Result<TOk, TFail> result,  ValueTask<Result<TOk, TFail>> fallbackAsync) 
        => result.IsFail ? await fallbackAsync : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> fallbackFn)
    {
        var result = await resultTask;
        return result.IsFail ? fallbackFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TOk, TFail>>> fallbackFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackFnAsync() : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TOk, TFail>>> fallbackFnAsync) 
        => result.IsFail ? await fallbackFnAsync() : result;
 
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask MatchAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<TOk> okAction, Action<TFail> failAction)
    {
        var result = await resultTask;
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
    public static async ValueTask MatchAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> okAction, Action<Result<TOk, TFail>> failAction)
    {
        var result = await resultTask;
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
    public static async ValueTask<TNewOk> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, TNewOk ok, TNewOk fail)
    {
        var result = await resultTask;
        return result.IsOk ? ok : fail;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<TNewOk> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<TNewOk>> okFnAsync, Func<ValueTask<TNewOk>> failFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await okFnAsync() : await failFnAsync();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<TNewOk> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<TNewOk>> okFnAsync, Func<ValueTask<TNewOk>> failFnAsync)
        => result.IsOk ? await okFnAsync() : await failFnAsync();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TNewOk, TFail>> okFn, Func<Result<TNewOk, TFail>> failFn)
    {
        var result = await resultTask;
        return result.IsOk ? okFn() : failFn();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TNewOk, TFail>>> okFnAsync, Func<ValueTask<Result<TNewOk, TFail>>> failFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await okFnAsync() : await failFnAsync();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TNewOk, TFail>>> okFnAsync, Func<ValueTask<Result<TNewOk, TFail>>> failFnAsync)
        => result.IsOk ? await okFnAsync() : await failFnAsync();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TNewOk, TFail>> okFn, TNewOk fail)
    {
        var result = await resultTask;
        return result.IsOk ? okFn() : Result.Ok<TNewOk, TFail>(fail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TNewOk, TFail>>> okFnAsync, TNewOk fail)
    {
        var result = await resultTask;
        return result.IsOk ? await okFnAsync() : Result.Ok<TNewOk, TFail>(fail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TNewOk, TFail>>> okFnAsync, TNewOk fail) 
        => result.IsOk ? await okFnAsync() : Result.Ok<TNewOk, TFail>(fail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, TNewOk ok, Func<Result<TNewOk, TFail>> failFn)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : failFn();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, TNewOk ok, Func<ValueTask<Result<TNewOk, TFail>>> failFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : await failFnAsync();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, TNewOk ok, Func<ValueTask<Result<TNewOk, TFail>>> failFnAsync)
        => result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : await failFnAsync();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TNewOk> okFn, TNewOk fail)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(okFn()) : Result.Ok<TNewOk, TFail>(fail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<TNewOk>> okFnAsync, TNewOk fail)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(await okFnAsync()) : Result.Ok<TNewOk, TFail>(fail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<TNewOk>> okFnAsync, TNewOk fail)
        => result.IsOk ? Result.Ok<TNewOk, TFail>(await okFnAsync()) : Result.Ok<TNewOk, TFail>(fail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, TNewOk ok, Func<TNewOk> failFn)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : Result.Ok<TNewOk, TFail>(failFn());
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, TNewOk ok, Func<ValueTask<TNewOk>> failFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : Result.Ok<TNewOk, TFail>(await failFnAsync());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MatchAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, TNewOk ok, Func<ValueTask<TNewOk>> failFnAsync) 
        => result.IsOk ? Result.Ok<TNewOk, TFail>(ok) : Result.Ok<TNewOk, TFail>(await failFnAsync());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, TNewOk>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? Result.Ok<TNewOk, TFail>(resultFn.Reduce(result.Reduce))
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, ValueTask<TNewOk>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Reduce(result.Reduce))
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, ValueTask<TNewOk>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Reduce(result.Reduce))
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Reduce(result.Reduce)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Reduce(result.Reduce)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Reduce(result.Reduce)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Reduce(result)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFn.ReduceFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Reduce(result)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Reduce(result)
            : Result.Fail<TNewOk, TFail>(result.ReduceFailOr(resultFnAsync.ReduceFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, TNewOk> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(combineFn(resultLt.Reduce, resultRt.Reduce))
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, ValueTask<TNewOk>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Reduce, resultRt.Reduce))
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<TOkLt, TOkRt, ValueTask<TNewOk>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Reduce, resultRt.Reduce))
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Result<TNewOk, TFail>> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? combineFn(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, ValueTask<Result<TNewOk, TFail>>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, ValueTask<Result<TNewOk, TFail>>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.ReduceFailOr(resultRt.ReduceFail));
}