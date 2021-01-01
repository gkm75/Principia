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

        public static Option<T> Join<T>(Option<Option<T>> option)
            => option.IsSome ? option.Value : Option.None<T>();
    }
}
