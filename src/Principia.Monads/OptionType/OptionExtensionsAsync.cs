using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class OptionExtensionsAsync
    {
        public static async Task<Monad<T>> PureAsync<T>(this Task<T> task)
            => Option.Some(await task);

        public static Task<T> ValueOrAsync<T>(this Option<Task<T>> option, T fallback)
            => option.IsSome ? option.Value : Task.FromResult(fallback);

        public static Task<T> ValueOrNullAsync<T>(this Option<Task<T>> option) where T : class
            => option.IsSome ? option.Value : Task.FromResult<T>(null);

        public static Task<T> ValueOrDefaultAsync<T>(this Option<Task<T>> option)
            => option.IsSome ? option.Value : Task.FromResult<T>(default);

        public static Option<Task<T>> JoinAsync<T>(Option<Option<Task<T>>> option)
            => option.IsSome ? option.Value : Option.None<Task<T>>();

        public static Task<Option<T>> JoinAsync<T>(Option<Task<Option<T>>> option)
            => option.IsSome ? option.Value : Task.FromResult(Option.None<T>());
    }
}
