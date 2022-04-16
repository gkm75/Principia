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

        public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action okAction)
        {
            if (result.IsOk && okAction != null)
                okAction();

            return result;
        }

        public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action<TOk> okAction) 
        {
            if (result.IsOk && okAction != null)
                okAction(result.Value);

            return result;
        }

        public static Result<TOk, TFail> WhenOk<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> okAction) 
        {
            if (result.IsOk && okAction != null)
                okAction(result);

            return result;
        }

        public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action failAction)
        {
            if (result.IsFail && failAction != null)
                failAction();

            return result;
        }
        
        public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action<TFail> failAction)
        {
            if (result.IsFail && failAction != null)
                failAction(result.FailValue);

            return result;
        }

        public static Result<TOk, TFail> WhenFail<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> failAction)
        {
            if (result.IsFail && failAction != null)
                failAction(result);

            return result;
        }

        public static Result<TOk, TFail> Match<TOk, TFail>(this Result<TOk, TFail> result, Action okAction, Action failAction)
        {
            if (result.IsOk && okAction != null)
                okAction();
            else 
                failAction?.Invoke();

            return result;
        }

        public static Result<TOk, TFail> Match<TOk, TFail>(this Result<TOk, TFail> result, Action<TOk> okAction, Action<TFail> failAction)
        {
            if (result.IsOk && okAction != null)
                okAction(result.Value);
            else 
                failAction?.Invoke(result.FailValue);

            return result;
        }

        public static Result<TOk, TFail> Match<TOk, TFail>(this Result<TOk, TFail> result, Action<Result<TOk, TFail>> okAction, Action<Result<TOk, TFail>> failAction)
        {
            if (result.IsOk && okAction != null)
                okAction(result);
            else 
                failAction?.Invoke(result);

            return result;
        }

        public static U Substitute<TOk, TFail, U>(this Result<TOk, TFail> result, U ok, U fail)
            => (result.IsOk) ? ok : fail;

        public static Result<TOk, TFail> OnOk<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk> okFn)
            => (result.IsOk && okFn != null) ? Result.From<TOk, TFail>(okFn()) : result;

        public static Result<TOk, TFail> OnOk<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>> okFn)
            => (result.IsOk && okFn != null) ? okFn() : result;

        public static Result<TOk, TFail> OnOk<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TOk, TFail>> okFn)
            => (result.IsOk && okFn != null) ? okFn(result.Value) : result;

        public static Result<TOk, TFail> OnOk<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Result<TOk, TFail>> okFn)
            => (result.IsOk && okFn != null) ? okFn(result) : result;

        public static Result<TOk, TFail> OnFail<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>> failFn)
            => (result.IsFail && failFn != null) ? failFn() : result;

        public static Result<TOk, TFail> OnFail<TOk, TFail>(this Result<TOk, TFail> result, Func<TFail, Result<TOk, TFail>> failFn)
            => (result.IsFail && failFn != null) ? failFn(result.FailValue) : result;

        public static Result<TOk, TFail> OnFail<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Result<TOk, TFail>> failFn)
            => (result.IsFail && failFn != null) ? failFn(result) : result;

        public static Result<UOk, TFail> Bimap<TOk, UOk, TFail>(this Result<TOk, TFail> result, Func<TOk, UOk> okFn, Func<UOk> failFn)
            => (result.IsOk && okFn != null) ? Result.Ok<UOk, TFail>(okFn(result.Value)) : Result.Ok<UOk, TFail>(failFn());

        public static Result<UOk, TFail> Bimap<TOk, UOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Result<UOk, TFail>> okFn, Func<Result<UOk, TFail>> failFn)
            => (result.IsOk && okFn != null) ? okFn(result) : failFn();

        public static Result<TOk, TFail> CombineAdditive<TOk, TFail>(this Result<TOk, TFail> result, Result<TOk, TFail> resultCombine, Func<TOk, TOk, TOk> additiveFn)
        {
            if (result.IsFail)
                return resultCombine;

            if (resultCombine.IsFail)
                return result;

            return Result.Ok<TOk, TFail>(additiveFn(result.Value, resultCombine.Value));
        }

        public static Result<TOk, TFail> CombineMultiplicative<TOk, TFail>(this Result<TOk, TFail> result, Result<TOk, TFail> resultCombine, Func<TOk, TOk, TOk> multiplicativeFn)
        {
            if (result.IsFail)
                return result;

            if (resultCombine.IsFail)
                return resultCombine;

            return Result.Ok<TOk, TFail>(multiplicativeFn(result.Value, resultCombine.Value));
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, TOk> tryFn, TFail fail)
        {
            try
            {
                return Result.FromOr<TOk, TFail>(tryFn(result.Value), fail);
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, TOk> tryFn, Result<TOk, TFail> resultFail)
        {
            try
            {
                return Result.Ok<TOk, TFail>(tryFn(result.Value));
            }
            catch
            {
                return resultFail;
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TOk, TFail>> tryFn, Result<TOk, TFail> resultFail)
        {
            try
            {
                return tryFn(result.Value);
            }
            catch
            {
                return result;
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Result<TOk, TFail>> tryFn, TFail fail)
        {
            try
            {
                return tryFn(result.Value);
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }
    }
}
