using System;

namespace Principia.Monads
{
    public static class Option
    {
        public static Option<T> Some<T>(T value) => new Option<T>(true, value);

        public static Option<T> None<T>() => Option<T>.None;

        public static Option<T> From<T>(T value) => value == null ? None<T>() : Some(value);

        public static Option<T> Try<T>(Func<T> tryFn)
        {
            try
            {
                return Option.Some(tryFn());
            }
            catch
            {
                return Option.None<T>();
            }
        }
    }
}
