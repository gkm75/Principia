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

        public static Option<T> WhenSome<T>(this Option<T> option, Action action)
        {
            if (option.IsSome)
                action?.Invoke();

            return option;
        }

        public static Option<T> WhenSome<T>(this Option<T> option, Action<T> action)
        {
            if (option.IsSome)
                action?.Invoke(option.Value);

            return option;
        }

        public static Option<T> WhenSome<T>(this Option<T> option, Action<Option<T>> action)
        {
            if (option.IsSome)
                action?.Invoke(option);

            return option;
        }

        public static Option<T> WhenNone<T>(this Option<T> option, Action action)
        {
            if (option.IsNone)
                action?.Invoke();

            return option;
        }

        public static Option<T> Match<T>(this Option<T> option, Action actionSome, Action actionNone)
        {
            if (option.IsSome)
                actionSome?.Invoke();
            else
                actionNone?.Invoke();

            return option;
        }

        public static Option<T> Match<T>(this Option<T> option, Action<T> actionSome, Action actionNone)
        {
            if (option.IsSome)
                actionSome?.Invoke(option.Value);
            else
                actionNone?.Invoke();

            return option;
        }

        public static Option<T> Match<T>(this Option<T> option, Action<Option<T>> actionSome, Action actionNone)
        {
            if (option.IsSome)
                actionSome?.Invoke(option);
            else
                actionNone?.Invoke();

            return option;
        }

        public static Option<T> OnNone<T>(this Option<T> option, Func<T> noneFn)
            => (option.IsNone && noneFn != null) ? Option.Some(noneFn()) : option;

        public static Option<T> OnNone<T>(this Option<T> option, Func<Option<T>> noneFn)
            => (option.IsNone && noneFn!=null) ? noneFn() : option;

        public static Option<T> OnSome<T>(this Option<T> option, Func<T, T> someFn)
            => (option.IsSome && someFn != null) ? Option.Some(someFn(option.Value)) : option;

        public static Option<T> OnSome<T>(this Option<T> option, Func<Option<T>, Option<T>> someFn)
            => (option.IsSome && someFn != null) ? someFn(option) : option;

        public static Option<U> Bimap<T, U>(this Option<T> option, Func<T, U> someFn, Func<U> noneFn)
            => (option.IsSome && someFn != null) ? Option.Some(someFn(option.Value)) : ((noneFn == null) ? Option.None<U>() : Option.Some(noneFn()));

        public static Option<U> Bimap<T, U>(this Option<T> option, Func<Option<T>, Option<U>> someFn, Func<Option<U>> noneFn)
            => (option.IsSome && someFn != null) ? someFn(option) : ((noneFn == null) ? Option.None<U>() : noneFn());

        public static Option<T> CombineAdditive<T>(this Option<T> option, Option<T> optionAdd, Func<T,T,T> additiveFn)
        {
            if (optionAdd.IsNone)
                return option;

            if (option.IsNone)
                return optionAdd;

            return Option.Some(additiveFn(option.Value, optionAdd.Value));
        }

        public static Option<T> CombineMultiplicative<T>(this Option<T> option, Option<T> optionAdd, Func<T, T, T> multiplicativeFn)
        {
            if (optionAdd.IsNone || option.IsNone)
                return Option.None<T>();

            return Option.Some(multiplicativeFn(option.Value, optionAdd.Value));
        }

        public static Option<U> Try<T, U>(this Option<T> option, Func<T, U> tryFn)
        {
            try
            {
                return Option.Some(tryFn(option.Value));
            }
            catch
            {
                return Option.None<U>();
            }
        }
    }
}
