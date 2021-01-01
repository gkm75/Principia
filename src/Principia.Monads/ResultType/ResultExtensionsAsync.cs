using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class ResultExtensionsAsync
    {
        public static async Task<Monad<T>> PureAsync<T, U>(this Task<T> task)
            => Result.Ok<T, U>(await task);

        public static Result<Task<T>, U> JoinAsync<T, U>(Result<Result<Task<T>, U>, U> result)
            => result.IsOk ? result.Value : Result.Fail<Task<T>, U>(result.FailValue);

        public static Task<Result<T, U>> JoinAsync<T, U>(Result<Task<Result<T, U>>, U> result)
            => result.IsOk ? result.Value : Task.FromResult(Result.Fail<T, U>(result.FailValue));
    }
}
