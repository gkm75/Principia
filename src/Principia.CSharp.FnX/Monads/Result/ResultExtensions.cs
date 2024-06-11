namespace Principia.CSharp.FnX.Monads;

public static class ResultExtensions
{
    public static void Deconstruct<TOk, TFail>(this IResult<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ReduceOr(default(TOk));
        fail = result.ReduceFailOr(default(TFail));
    }
    
    public static void Deconstruct<TOk, TFail>(this Result<TOk, TFail> result, out bool hasValue, out TOk ok, out TFail fail)
    {
        hasValue = result.HasValue;
        ok = result.ReduceOr(default(TOk));
        fail = result.ReduceFailOr(default(TFail));
    }
}