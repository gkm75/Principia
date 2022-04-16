using System;

namespace Principia.Monads
{
    public static class Option
    {
        public static Monad<T> Pure<T>(T value) => From(value);

        public static Option<T> Some<T>(T value) => new Option<T>(true, value);

        public static Option<T> None<T>() => Option<T>.None;

        public static Option<T> From<T>(T value) => value == null ? None<T>() : Some(value);

        public static Option<T> FromFunc<T>(Func<T> fromFn) => fromFn == null ? None<T>() : From(fromFn());

        public static Option<T> Try<T>(Func<T> tryFn)
        {
            try
            {
                return Option.From(tryFn());
            }
            catch
            {
                return Option.None<T>();
            }
        }
    }
}
