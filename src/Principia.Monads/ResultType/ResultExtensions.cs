using System;

namespace Principia.Monads.ResultType
{
    public static class ResultExtensions
    {
        public static Monad<TOk> Pure<TOk, TFail>(this TOk obj)
            => Result.Ok<TOk, TFail>(obj);

        public static Result<TOk, TFail> Join<TOk, TFail>(this Result<Result<TOk, TFail>, TFail> result)
            => result.IsOk ? result.Value : Result.Fail<TOk, TFail>(result.FailValue);

        public static Result<TOk, TFail> Bind<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TOk, TFail>> bindFn)
            => result.IsOk ? bindFn(result.Value) : result;

        public static Result<UOk, TFail> Map<TOk, TFail, UOk>(this Result<TOk, TFail> result, Func<TOk, UOk> mapFn)
            => result.IsOk 
                ? Result.FromOr(mapFn(result.Value), result.FailValue) 
                : Result.Fail<UOk, TFail>(result.FailValue);

        public static Result<UOk, TFail> Applicative<TOk, TFail, UOk>(this Result<TOk, TFail> result, Result<Func<TOk, UOk>, TFail> resultMapFn)
            => result.IsOk && resultMapFn.IsOk
                ? Result.FromOr(resultMapFn.Value(result.Value), result.FailValue)
                : Result.Fail<UOk, TFail>(result.FailValue);
    }
}
