using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Principia.CSharp.FnX.Monads;

public static class ResultAsyncExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<IEnumerable<TOk>> ToEnumerableAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask)
    {
        var result = await resultTask;
        return result.IsOk ? new[] {result.Value} : Enumerable.Empty<TOk>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Task<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> MapAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Task<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk> mapFn)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(mapFn(), result.ValueFail) : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Task<TOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(await mapFnAsync(), result.ValueFail) : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> MapFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Task<TOk>> mapFnAsync) 
        => result.IsFail ? Result.From(await mapFnAsync(), result.ValueFail) : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Task<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> BindAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Task<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsFail ? bindFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Task<Result<TOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await bindFnAsync() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> BindFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Task<Result<TOk, TFail>>> bindFnAsync) 
        => result.IsFail ? await bindFnAsync() : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> JoinAsync<TOk, TFail>(this Task<Result<Result<TOk, TFail>, TFail>> resultTask)
    {
        var result = await resultTask;
        return result.IsOk ? result.Value : Result.Fail<TOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> JoinAsync<TOk, TFail>(this Result<Task<Result<TOk, TFail>>, TFail> result)
    {
        return result.IsOk ? await result.Value : Result.Fail<TOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, bool> predicate)
    {
        var result = await resultTask;
        return result.IsOk && predicate(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<bool>> predicateAsync)
    {
        var result = await resultTask;
        return result.IsOk && await predicateAsync(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> FilterAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<bool>> predicateAsync)
        => result.IsOk && await predicateAsync(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<TOk> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result.Value);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<TFail> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result.ValueFail);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<TOk, TFail> fallback)
    {
        var result = await resultTask;
        return result.IsFail ? fallback : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask,  Task<Result<TOk, TFail>> fallbackAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackAsync : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Result<TOk, TFail> result,  Task<Result<TOk, TFail>> fallbackAsync) 
        => result.IsFail ? await fallbackAsync : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> fallbackFn)
    {
        var result = await resultTask;
        return result.IsFail ? fallbackFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Task<Result<TOk, TFail>>> fallbackFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackFnAsync() : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TOk, TFail>> OrAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Task<Result<TOk, TFail>>> fallbackFnAsync) 
        => result.IsFail ? await fallbackFnAsync() : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, TNewOk>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? Result.Ok<TNewOk, TFail>(resultFn.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, Task<TNewOk>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, Task<TNewOk>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, Task<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, Task<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, Task<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> ApplyAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<Result<TOk, TFail>, Task<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Task<Result<TOkLt, TFail>> resultLtTask, Task<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, TNewOk> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(combineFn(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Task<Result<TOkLt, TFail>> resultLtTask, Task<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, Task<TNewOk>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<TOkLt, TOkRt, Task<TNewOk>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Task<Result<TOkLt, TFail>> resultLtTask, Task<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Result<TNewOk, TFail>> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? combineFn(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Task<Result<TOkLt, TFail>> resultLtTask, Task<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Task<Result<TNewOk, TFail>>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<Result<TNewOk, TFail>> CombineAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Task<Result<TNewOk, TFail>>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
}

public static class ResultValueAsyncExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<IEnumerable<TOk>> ToEnumerableValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask)
    {
        var result = await resultTask;
        return result.IsOk ? new[] {result.Value} : Enumerable.Empty<TOk>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result.Value), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, TNewOk> mapFn)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(mapFn(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, ValueTask<TNewOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> MapValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, ValueTask<TNewOk>> mapFnAsync) 
        => result.IsOk
            ? Result.From<TNewOk, TFail>(await mapFnAsync(result), result.ValueFail)
            : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk> mapFn)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(mapFn(), result.ValueFail) : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<TOk>> mapFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? Result.From(await mapFnAsync(), result.ValueFail) : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> MapFailValueAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<TOk>> mapFnAsync) 
        => result.IsFail ? Result.From(await mapFnAsync(), result.ValueFail) : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result.Value) : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<TNewOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsOk ? bindFn(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> BindValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>> bindFnAsync) 
        => result.IsOk ? await bindFnAsync(result) : Result.Fail<TNewOk, TFail>(result.ValueFail);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> bindFn)
    {
        var result = await resultTask;
        return result.IsFail ? bindFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TOk, TFail>>> bindFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await bindFnAsync() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> BindFailValueAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TOk, TFail>>> bindFnAsync) 
        => result.IsFail ? await bindFnAsync() : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> JoinValueAsync<TOk, TFail>(this ValueTask<Result<Result<TOk, TFail>, TFail>> resultTask)
    {
        var result = await resultTask;
        return result.IsOk ? result.Value : Result.Fail<TOk, TFail>(result.ValueFail);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> JoinValueAsync<TOk, TFail>(this Result<ValueTask<Result<TOk, TFail>>, TFail> result)
    {
        return result.IsOk ? await result.Value : Result.Fail<TOk, TFail>(result.ValueFail);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, bool> predicate)
    {
        var result = await resultTask;
        return result.IsOk && predicate(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<TOk, ValueTask<bool>> predicateAsync)
    {
        var result = await resultTask;
        return result.IsOk && await predicateAsync(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> FilterValueAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, ValueTask<bool>> predicateAsync)
        => result.IsOk && await predicateAsync(result.Value)
            ? result
            : result.IsFail
                ? result
                : Result.Fail<TOk, TFail>(default);
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenOkValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<TOk> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result.Value);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<TFail> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result.ValueFail);
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenOkValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsOk)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> WhenFailValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> action)
    {
        var result = await resultTask;
        if (result.IsFail)
        {
            action(result);
        }

        return result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<TOk, TFail> fallback)
    {
        var result = await resultTask;
        return result.IsFail ? fallback : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask,  ValueTask<Result<TOk, TFail>> fallbackAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackAsync : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this Result<TOk, TFail> result,  ValueTask<Result<TOk, TFail>> fallbackAsync) 
        => result.IsFail ? await fallbackAsync : result;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> fallbackFn)
    {
        var result = await resultTask;
        return result.IsFail ? fallbackFn() : result;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Func<ValueTask<Result<TOk, TFail>>> fallbackFnAsync)
    {
        var result = await resultTask;
        return result.IsFail ? await fallbackFnAsync() : result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TOk, TFail>> OrValueAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<ValueTask<Result<TOk, TFail>>> fallbackFnAsync) 
        => result.IsFail ? await fallbackFnAsync() : result;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, TNewOk>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? Result.Ok<TNewOk, TFail>(resultFn.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, ValueTask<TNewOk>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, ValueTask<TNewOk>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? Result.Ok<TNewOk, TFail>(await resultFnAsync.Value(result.Value))
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<TOk, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<TOk, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result.Value)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, Result<TNewOk, TFail>>, TFail> resultFn)
    {
        var result = await resultTask;
        return result.IsOk && resultFn.IsOk
            ? resultFn.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFn.ValueFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this ValueTask<Result<TOk, TFail>> resultTask, Result<Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
    {
        var result = await resultTask;
        return result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> ApplyValueAsync<TOk, TNewOk, TFail>(this Result<TOk, TFail> result, Result<Func<Result<TOk, TFail>, ValueTask<Result<TNewOk, TFail>>>, TFail> resultFnAsync)
        => result.IsOk && resultFnAsync.IsOk
            ? await resultFnAsync.Value(result)
            : Result.Fail<TNewOk, TFail>(result.FailValueOr(resultFnAsync.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, TNewOk> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(combineFn(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<TOkLt, TOkRt, ValueTask<TNewOk>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<TOkLt, TOkRt, ValueTask<TNewOk>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? Result.Ok<TNewOk, TFail>(await combineFnAsync(resultLt.Value, resultRt.Value))
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, Result<TNewOk, TFail>> combineFn)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? combineFn(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this ValueTask<Result<TOkLt, TFail>> resultLtTask, ValueTask<Result<TOkRt, TFail>> resultRtTask, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, ValueTask<Result<TNewOk, TFail>>> combineFnAsync)
    {
        var resultLt = await resultLtTask;
        var resultRt = await resultRtTask;
        return resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Result<TNewOk, TFail>> CombineValueAsync<TOkLt, TOkRt, TNewOk, TFail>(this Result<TOkLt, TFail> resultLt, Result<TOkRt, TFail> resultRt, Func<Result<TOkLt, TFail>, Result<TOkRt, TFail>, ValueTask<Result<TNewOk, TFail>>> combineFnAsync)
        => resultLt.IsOk && resultRt.IsOk
            ? await combineFnAsync(resultLt, resultRt)
            : Result.Fail<TNewOk, TFail>(resultLt.FailValueOr(resultRt.ValueFail));
}
