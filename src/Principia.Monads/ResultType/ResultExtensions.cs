namespace Principia.Monads.ResultType
{
    public static class ResultExtensions
    {
        public static Monad<T> Pure<T, U>(this T obj)
            => Result.Ok<T, U>(obj);

        public static Result<T, U> Join<T, U>(Result<Result<T, U>, U> result)
            => result.IsOk ? result.Value : Result.Fail<T, U>(result.FailValue);
    }
}
