using System;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Monads;

public static class OptionExtensions
{
    public static void Deconstruct<T>(this IOption<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ReduceOr(default(T));
    }

    public static void Deconstruct<T>(this Option<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ReduceOr(default(T));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> mapFn)
        => option.IsSome ? Option.From(mapFn(option.Reduce)) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Map<T, U>(this Option<T> option, Func<Option<T>, U> mapFn)
        => option.IsSome ? Option.From(mapFn(option)) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> MapNone<T, U>(this Option<T> option, Func<T> mapFn)
        => option.IsNone ? Option.From(mapFn()) : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Bind<T, U>(this Option<T> option, Func<T, Option<U>> bindFn)
        => option.IsSome ? bindFn(option.Reduce) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Bind<T, U>(this Option<T> option, Func<Option<T>, Option<U>> bindFn)
        => option.IsSome ? bindFn(option) : Option.None<U>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> BindNone<T>(this Option<T> option, Func<Option<T>> bindFn)
        => option.IsNone ? bindFn() : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Join<T>(this Option<Option<T>> option)
        => option.IsSome ? option.Reduce : Option.None<T>();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Filter<T>(this Option<T> option, Func<T, bool> predicate)
        => option.IsSome && predicate(option.Reduce) ? option : Option.None<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> Filter<T>(this Option<T> option, Func<Option<T>, bool> predicate)
        => option.IsSome && predicate(option) ? option : Option.None<T>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> WhenSome<T>(this Option<T> option, Action<T> action)
    {
        if (option.IsSome)
        {
            action(option.Reduce);
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
    public static Option<T> WhenSome<T>(this Option<T> option, Action<Option<T>> action)
    {
        if (option.IsSome)
        {
            action(option);
        }

        return option;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<T> WhenNone<T>(this Option<T> option, Action<Option<T>> action)
    {
        if (option.IsNone)
        {
            action(option);
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
    public static Option<T> Or<T>(this Option<T> option, Func<Option<T>> fallbackFn)
        => option.IsNone ? fallbackFn() : option;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Match<T>(this Option<T> option, Action<T> someAction, Action noneAction)
    {
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
    public static void Match<T>(this Option<T> option, Action<Option<T>> someAction, Action noneAction)
    {
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
    public static U Match<T, U>(this Option<T> option, U some, U none)
        => option.IsSome ? some : none;
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Match<T, U>(this Option<T> option, Option<U> some, Option<U> none)
        => option.IsSome ? some : none;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static U Match<T, U>(this Option<T> option, Func<U> someFn, Func<U> noneFn)
        => option.IsSome ? someFn() : noneFn();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static U Match<T, U>(this Option<T> option, U some, Func<U> noneFn)
        => option.IsSome ? some : noneFn();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static U Match<T, U>(this Option<T> option, Func<U> someFn, U none)
        => option.IsSome ? someFn() : none;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static U Match<T, U>(this Option<T> option, Func<T, U> some, U none)
        => option.IsSome ? option.Map(some).Reduce : none;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static U Match<T, U>(this Option<T> option, Func<T, U> some, Func<U> noneFn)
        => option.IsSome ? option.Map(some).Reduce : noneFn();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Apply<T, U>(this Option<T> option, Option<Func<T, U>> optionFn)
        => option.IsSome && optionFn.IsSome ? Option.Some(optionFn.Reduce(option.Reduce)) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Apply<T, U>(this Option<T> option, Option<Func<T, Option<U>>> optionFn)
        => option.IsSome && optionFn.IsSome ? optionFn.Reduce(option.Reduce) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<U> Apply<T, U>(this Option<T> option, Option<Func<Option<T>, Option<U>>> optionFn)
        => option.IsSome && optionFn.IsSome ? optionFn.Reduce(option) : Option.None<U>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<V> Combine<T, U, V>(this Option<T> option, Option<U> option2, Func<T, U, V> combineFn)
        => option.IsSome && option2.IsSome ? Option.From(combineFn(option.Reduce, option2.Reduce)) : Option.None<V>();
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Option<V> Combine<T, U, V>(this Option<T> option, Option<U> option2, Func<Option<T>, Option<U>, Option<V>> combineFn)
        => option.IsSome && option2.IsSome ? combineFn(option, option2) : Option.None<V>();
}
