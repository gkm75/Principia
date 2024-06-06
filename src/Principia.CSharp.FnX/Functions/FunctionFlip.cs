using System;

namespace Principia.CSharp.FnX;

public static partial class Function
{
    public static Func<T2, T1, TResult> Flip<T1, T2, TResult>
            (this Func<T1, T2, TResult> fn)
        => (p2, p1) => fn(p1, p2);
    
    public static Func<T3, T2, T1, TResult> Flip<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn)
        => (p3, p2, p1) => fn(p1, p2, p3);
    
    public static Func<T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn)
        => (p4, p3, p2, p1) => fn(p1, p2, p3, p4);
    
    public static Func<T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, TResult>
            (this Func<T1, T2, T3, T4, T5, TResult> fn)
        => (p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5);
    
    public static Func<T6, T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, T6, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, TResult> fn)
        => (p6, p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T7, T6, T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn)
        => (p7, p6, p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T8, T7, T6, T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn)
        => (p8, p7, p6, p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T9, T8, T7, T6, T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn)
        => (p9, p8, p7, p6, p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    public static Func<T10, T9, T8, T7, T6, T5, T4, T3, T2, T1, TResult> Flip<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn)
        => (p10, p9, p8, p7, p6, p5, p4, p3, p2, p1) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}