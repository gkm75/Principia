using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Principia.CSharp.FnX.Monads;

public static class OptionAsyncExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<IEnumerable<T>> ToEnumerableAsync<T>(this ValueTask<Option<T>> optionTask)
    {
        var option = await optionTask;
        return option.IsSome ? new[] {option.Reduce} : Enumerable.Empty<T>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, ValueTask<U>> mapFnAsync)
    {
        var option = await optionTask;
        return option.IsSome ? Option.From(await mapFnAsync(option.Reduce)) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this Option<T> option, Func<T, ValueTask<U>> mapFnAsync)
        => option.IsSome ? Option.From(await mapFnAsync(option.Reduce)) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, U> mapFn)
    {
        var option = await optionTask;
        return option.IsSome ? Option.From(mapFn(option.Reduce)) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<Option<T>, ValueTask<U>> mapFnAsync)
    {
        var option = await optionTask;
        return option.IsSome ? Option.From(await mapFnAsync(option)) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this Option<T> option, Func<Option<T>, ValueTask<U>> mapFnAsync)
        => option.IsSome ? Option.From(await mapFnAsync(option)) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MapAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<Option<T>, U> mapFn)
    {
        var option = await optionTask;
        return option.IsSome ? Option.From(mapFn(option)) : Option.None<U>();
    }
    

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> MapNone<T, U>(this ValueTask<Option<T>> optionTask, Func<T> mapFn)
    {
        var option = await optionTask;
        return option.IsNone ? Option.From(mapFn()) : option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> MapNone<T, U>(this Option<T> option, Func<Task<T>> mapFn)
        => option.IsNone ? Option.From(await mapFn()) : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, Option<U>> bindFn)
    {
        var option = await optionTask;
        return option.IsSome ? bindFn(option.Reduce) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, ValueTask<Option<U>>> bindFnAsync)
    {
        var option = await optionTask;
        return option.IsSome ? await bindFnAsync(option.Reduce) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this Option<T> option, Func<T, ValueTask<Option<U>>> bindFnAsync) 
        => option.IsSome ? await bindFnAsync(option.Reduce) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<Option<T>, Option<U>> bindFn)
    {
        var option = await optionTask;
        return option.IsSome ? bindFn(option) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<Option<T>, ValueTask<Option<U>>> bindFnAsync)
    {
        var option = await optionTask;
        return option.IsSome ? await bindFnAsync(option) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> BindAsync<T, U>(this Option<T> option, Func<Option<T>, ValueTask<Option<U>>> bindFnAsync) 
        => option.IsSome ? await bindFnAsync(option) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> BindNoneAsync<T>(this ValueTask<Option<T>> optionTask, Func<ValueTask<Option<T>>> bindFnAsync)
    {
        var option = await optionTask;
        return option.IsNone ? await bindFnAsync() : option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> BindNoneAsync<T>(this ValueTask<Option<T>> optionTask, Func<Option<T>> bindFn)
    {
        var option = await optionTask;
        return option.IsNone ? bindFn() : option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> BindNoneAsync<T>(this Option<T> option, Func<ValueTask<Option<T>>> bindFnAsync) 
        => option.IsNone ? await bindFnAsync() : option;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> JoinAsync<T>(this ValueTask<Option<Option<T>>> optionTask)
    {
        var option = await optionTask;
        return option.IsSome ? option.Reduce : Option.None<T>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> JoinAsync<T>(this Option<ValueTask<Option<T>>> option) 
        => option.IsSome ? await option.Reduce : Option.None<T>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this ValueTask<Option<T>> optionTask, Func<T, bool> predicate)
    {
        var option = await optionTask;
        return option.IsSome && predicate(option.Reduce) ? option : Option.None<T>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this ValueTask<Option<T>> optionTask, Func<T, ValueTask<bool>> predicateAsync)
    {
        var option = await optionTask;
        return option.IsSome && await predicateAsync(option.Reduce) ? option : Option.None<T>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this Option<T> option, Func<T, ValueTask<bool>> predicateAsync) 
        => option.IsSome && await predicateAsync(option.Reduce) ? option : Option.None<T>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this ValueTask<Option<T>> optionTask, Func<Option<T>, bool> predicate)
    {
        var option = await optionTask;
        return option.IsSome && predicate(option) ? option : Option.None<T>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this ValueTask<Option<T>> optionTask, Func<Option<T>, ValueTask<bool>> predicateAsync)
    {
        var option = await optionTask;
        return option.IsSome && await predicateAsync(option) ? option : Option.None<T>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> Filter<T>(this Option<T> option, Func<Option<T>, ValueTask<bool>> predicateAsync) 
        => option.IsSome && await predicateAsync(option) ? option : Option.None<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> WhenSomeAsync<T>(this ValueTask<Option<T>> optionTask, Action<T> action)
    {
        var option = await optionTask;
        if (option.IsSome)
        {
            action(option.Reduce);
        }

        return option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> WhenNoneAsync<T>(this ValueTask<Option<T>> optionTask, Action action)
    {
        var option = await optionTask;
        if (option.IsNone)
        {
            action();
        }

        return option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> WhenSomeAsync<T>(this ValueTask<Option<T>> optionTask, Action<Option<T>> action)
    {
        var option = await optionTask;
        if (option.IsSome)
        {
            action(option);
        }

        return option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> WhenNoneAsync<T>(this ValueTask<Option<T>> optionTask, Action<Option<T>> action)
    {
        var option = await optionTask;
        if (option.IsNone)
        {
            action(option);
        }

        return option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, T fallback)
    {
        var option = await optionTask;
        return option.IsNone ? Option.From(fallback) : option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, Option<T> maybeFallback)
    {
        var option = await optionTask;
        return option.IsNone ? maybeFallback : option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, Func<Option<T>> fallbackFn)
    {
        var option = await optionTask;
        return option.IsNone ? fallbackFn() : option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, ValueTask<T> fallback)
    {
        var option = await optionTask;
        return option.IsNone ? Option.From(await fallback) : option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, ValueTask<Option<T>> maybeFallback)
    {
        var option = await optionTask;
        return option.IsNone ? await maybeFallback : option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this ValueTask<Option<T>> optionTask, Func<ValueTask<Option<T>>> fallbackFn)
    {
        var option = await optionTask;
        return option.IsNone ? await fallbackFn() : option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this Option<T> option, ValueTask<T> fallback) 
        => option.IsNone ? Option.From(await fallback) : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this Option<T> option, ValueTask<Option<T>> maybeFallback) 
        => option.IsNone ? await maybeFallback : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<T>> OrAsync<T>(this Option<T> option, Func<ValueTask<Option<T>>> fallbackFn) 
        => option.IsNone ? await fallbackFn() : option;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask MatchAsync<T>(this ValueTask<Option<T>> optionTask, Action<T> someAction, Action noneAction)
    {
        var option = await optionTask;
        if (option.IsSome)
        {
            someAction(option.Reduce);
        }
        else
        {
            noneAction();
        }
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask MatchAsync<T>(this ValueTask<Option<T>> optionTask, Action<Option<T>> someAction, Action noneAction)
    {
        var option = await optionTask;
        if (option.IsSome)
        {
            someAction(option);
        }
        else
        {
            noneAction();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, U some, U none)
    {
        var option = await optionTask;
        return option.IsSome ? some : none;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<U> some, Option<U> none)
    {
        var option = await optionTask;
        return option.IsSome ? some : none;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<U> someFn, Func<U> noneFn)
    {
        var option = await optionTask;
        return option.IsSome ? someFn() : noneFn();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, U some, Func<U> noneFn)
    {
        var option = await optionTask;
        return option.IsSome ? some : noneFn();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<U> someFn, U none)
    {
        var option = await optionTask;
        return option.IsSome ? someFn() : none;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, U> some, U none)
    {
        var option = await optionTask;
        return option.IsSome ? option.Map(some).Reduce : none;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<U> MatchAsync<T, U>(this ValueTask<Option<T>> optionTask, Func<T, U> some, Func<U> noneFn)
    {
        var option = await optionTask;
        return option.IsSome ? option.Map(some).Reduce : noneFn();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<T, U>> optionFn)
    {
        var option = await optionTask;
        return option.IsSome && optionFn.IsSome ? Option.From(optionFn.Reduce(option.Reduce)) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<T, Option<U>>> optionFn)
    {
        var option = await optionTask;
        return option.IsSome && optionFn.IsSome ? optionFn.Reduce(option.Reduce) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<Option<T>, Option<U>>> optionFn)
    {
        var option = await optionTask;
        return option.IsSome && optionFn.IsSome ? optionFn.Reduce(option) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<T, ValueTask<U>>> optionFnAsync)
    {
        var option = await optionTask;
        return option.IsSome && optionFnAsync.IsSome ? Option.From(await optionFnAsync.Reduce(option.Reduce)) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<T, ValueTask<Option<U>>>> optionFnAsync)
    {
        var option = await optionTask;
        return option.IsSome && optionFnAsync.IsSome ? await optionFnAsync.Reduce(option.Reduce) : Option.None<U>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this ValueTask<Option<T>> optionTask, Option<Func<Option<T>, ValueTask<Option<U>>>> optionFnAsync)
    {
        var option = await optionTask;
        return option.IsSome && optionFnAsync.IsSome ? await optionFnAsync.Reduce(option) : Option.None<U>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<U>> ApplyAsync<T, U>(this Option<T> option, Option<Func<T, ValueTask<U>>> optionFnAsync) 
        => option.IsSome && optionFnAsync.IsSome ? Option.From(await optionFnAsync.Reduce(option.Reduce)) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask<Option<U>> ApplyAsync<T, U>(this Option<T> option, Option<Func<T, ValueTask<Option<U>>>> optionFnAsync) 
        => option.IsSome && optionFnAsync.IsSome ? optionFnAsync.Reduce(option.Reduce) : ValueTask.FromResult(Option.None<U>());

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ValueTask<Option<U>> ApplyAsync<T, U>(this Option<T> option, Option<Func<Option<T>, ValueTask<Option<U>>>> optionFnAsync)
    {
        return option.IsSome && optionFnAsync.IsSome ? optionFnAsync.Reduce(option) : ValueTask.FromResult(Option.None<U>());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this ValueTask<Option<T>> optionTask, ValueTask<Option<U>> option2Task, Func<T, U, V> combineFn)
    {
        var (option, option2) = (await optionTask, await option2Task);
        return option.IsSome && option2.IsSome
            ? Option.From(combineFn(option.Reduce, option2.Reduce))
            : Option.None<V>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this ValueTask<Option<T>> optionTask, ValueTask<Option<U>> option2Task, Func<Option<T>, Option<U>, Option<V>> combineFn)
    {
        var (option, option2) = (await optionTask, await option2Task);
        return option.IsSome && option2.IsSome ? combineFn(option, option2) : Option.None<V>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this ValueTask<Option<T>> optionTask, Option<U> option2, Func<T, U, V> combineFn)
    {
        var option = await optionTask;
        return option.IsSome && option2.IsSome
            ? Option.From(combineFn(option.Reduce, option2.Reduce))
            : Option.None<V>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this ValueTask<Option<T>> optionTask, Option<U> option2, Func<Option<T>, Option<U>, Option<V>> combineFn)
    {
        var option = await optionTask;
        return option.IsSome && option2.IsSome ? combineFn(option, option2) : Option.None<V>();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this Option<T> option, ValueTask<Option<U>> option2Task, Func<T, U, V> combineFn)
    {
        var option2 = await option2Task;
        return option.IsSome && option2.IsSome
            ? Option.From(combineFn(option.Reduce, option2.Reduce))
            : Option.None<V>();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async ValueTask<Option<V>> CombineAsync<T, U, V>(this Option<T> option, ValueTask<Option<U>> option2Task, Func<Option<T>, Option<U>, Option<V>> combineFn)
    {
        var option2 = await option2Task;
        return option.IsSome && option2.IsSome ? combineFn(option, option2) : Option.None<V>();
    }
}
