using System;

namespace Principia.Monads
{
    public static class OptionExtensions
    {
        public static Monad<T> Pure<T>(this T obj)
            => Option.Some(obj);

        public static T ValueOr<T>(this Option<T> option, T fallback)
            => option.IsSome ? option.Value : fallback;

        public static T ValueOrNull<T>(this Option<T> option) where T : class
            => option.IsSome ? option.Value : null;

        public static T ValueOrDefault<T>(this Option<T> option)
            => option.IsSome ? option.Value : default;

        public static Option<T> Join<T>(this Option<Option<T>> option)
            => option.IsSome ? option.Value : Option.None<T>();

        public static Option<T> Bind<T>(this Option<T> option, Func<T, Option<T>> bindFn)
            => option.IsSome ? bindFn(option.Value) : Option.None<T>();

        public static Option<U> Map<T, U>(this Option<T> option, Func<T, U> mapFn)
            => option.IsSome ? Option.From(mapFn(option.Value)) : Option.None<U>();

        public static Option<U> Applicative<T, U>(this Option<T> option, Option<Func<T, U>> optionMapFn)
            => option.IsSome && optionMapFn.IsSome ? Option.From(optionMapFn.Value(option.Value)) : Option.None<U>();


        //Bimap/BiFunctor
        //Combine
        //When
        //On
        //Handle/Visit/Match
        //MapNone

        //Try-Catch

        //Chain

        //Pipeline
        //Compose

    }
}
