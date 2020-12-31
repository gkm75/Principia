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
    }
}
