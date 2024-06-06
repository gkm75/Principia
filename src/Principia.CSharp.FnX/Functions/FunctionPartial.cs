using System;

namespace Principia.CSharp.FnX;

public static partial class Function
{
    public static Func<TResult> Partial<T, TResult>
            (this Func<T, TResult> fn, T p)
        => () => fn(p);
    
    public static Func<T2, TResult> Partial<T1, T2, TResult>
            (this Func<T1, T2, TResult> fn, T1 p1)
        => p2 => fn(p1, p2);
    
    public static Func<T1, TResult> PartialLeft<T1, T2, TResult>
        (this Func<T1, T2, TResult> fn, T2 p2)
        => p1 => fn(p1, p2);

    public static Func<T2, T3, TResult> Partial<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T1 p1)
        => (p2, p3) => fn(p1, p2, p3);

    public static Func<T3, TResult> Partial<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T1 p1, T2 p2)
        => p3 => fn(p1, p2, p3);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T3 p3)
        => (p1, p2) => fn(p1, p2, p3);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T2 p2, T3 p3)
        => p1 => fn(p1, p2, p3);
}