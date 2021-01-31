using System;

namespace Principia.Monads
{
    public static class Result
    {
        public static Result<TOk, TFail> Ok<TOk, TFail>(TOk ok)
            => new ResultOk<TOk, TFail>(ok);

        public static Result<TOk, TFail> Fail<TOk, TFail>(TFail fail)
            => new ResultFail<TOk, TFail>(fail);

        public static Result<TOk, TFail> FromOr<TOk, TFail>(TOk ok, TFail fail)
            => ok == null 
                ? Fail<TOk, TFail>(fail) 
                : Ok<TOk, TFail>(ok);

        public static Result<TOk, TFail> Try<TOk, TFail>(Func<TOk> tryFn, TFail fail)
        {
            try
            {
                return Ok<TOk, TFail>(tryFn());
            }
            catch
            {
                return Fail<TOk, TFail>(fail);
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(Func<TOk> tryFn, Result<TOk, TFail> result)
        {
            try
            {
                return Ok<TOk, TFail>(tryFn());
            }
            catch
            {
                return result;
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(Func<Result<TOk, TFail>> tryFn, Result<TOk, TFail> result)
        {
            try
            {
                return tryFn();
            }
            catch
            {
                return result;
            }
        }

        public static Result<TOk, TFail> Try<TOk, TFail>(Func<Result<TOk, TFail>> tryFn, TFail fail)
        {
            try
            {
                return tryFn();
            }
            catch
            {
                return Fail<TOk, TFail>(fail);
            }
        }
    }
}
