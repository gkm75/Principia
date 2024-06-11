namespace Principia.CSharp.FnX.Monads;

public static class OptionExtensions
{
    public static void Deconstruct<T>(this IOption<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ReduceOr(default(T));
    }
    
    public static void Deconstruct<T>(this Option<T> option, out bool hasValue, out T value)
    {
        hasValue = option.HasValue;
        value = option.ReduceOr(default(T));
    }
}
