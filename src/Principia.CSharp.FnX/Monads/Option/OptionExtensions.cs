using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;


public static class OptionExtensions
{
    public static void Deconstruct<T>(this IOption<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ValueOr(default(T));
    }

    public static void Deconstruct<T>(this Option<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ValueOr(default(T));
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ToEnumerable<T>(this Option<T> option)
        => option.IsSome ? new []{ option.Value } : Enumerable.Empty<T>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> mapFn)
        => option.IsSome ? Option.From(mapFn(option.Value)) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> MapNone<T>(this Option<T> option, Func<T> mapFn)
        => option.IsNone ? Option.From(mapFn()) : option;

    // /// <summary>
    // /// Accepts a function which takes a T value and returns an Option &lt;U&gt;. The function is executed by
    // /// passing the value contained inside and the new Option is returned. This can be used to chain monadic
    // /// computations together.
    // /// </summary>
    // /// <param name="bindFn"></param>
    // /// <typeparam name="U"></typeparam>
    // /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> bindFn)
        => option.IsSome ? bindFn(option.Value) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> BindNone<T>(this Option<T> option, Func<Option<T>> bindFn)
        => option.IsNone ? bindFn() : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Join<T>(this Option<Option<T>> option)
        => option.IsSome ? option.Value : Option.None<T>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate)
        => option.IsSome && predicate(option.Value) ? option : Option.None<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> WhenSome<T>(this Option<T> option, Action action)
    {
        if (option.IsSome)
        {
            action();
        }

        return option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> WhenSome<T>(this Option<T> option, Action<T> action)
    {
        if (option.IsSome)
        {
            action(option.Value);
        }

        return option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> WhenNone<T>(this Option<T> option, Action action)
    {
        if (option.IsNone)
        {
            action();
        }

        return option;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Or<T>(this Option<T> option, T fallback)
        => option.IsNone ? Option.From(fallback) : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Or<T>(this Option<T> option, Option<T> maybeFallback)
        => option.IsNone ? maybeFallback : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Or<T>(this Option<T> option, Func<T> fallbackFn)
        => option.IsNone ? Option.From(fallbackFn()) : option;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Or<T>(this Option<T> option, Func<Option<T>> fallbackFn)
        => option.IsNone ? fallbackFn() : option;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Apply<T, U>(this Option<T> option, Option<Func<T, U>> optionFn)
        => option.IsSome && optionFn.IsSome ? Option.Some(optionFn.Value(option.Value)) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Apply<T, U>(this Option<T> option, Option<Func<T, Option<U>>> optionFn)
        => option.IsSome && optionFn.IsSome ? optionFn.Value(option.Value) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<V> Combine<T, U, V>(this Option<T> option, Option<U> option2, Func<T, U, V> combineFn)
        => option.IsSome && option2.IsSome ? Option.From(combineFn(option.Value, option2.Value)) : Option.None<V>();
}
