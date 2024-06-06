using System;

namespace Principia.CSharp.FnX;

public static partial class Function
{
    public static Func<Func<T1, TReturn>> Curry<T1, TReturn>
            (this Func<T1, TReturn> fn)
        => () => fn;
    
    public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>
            (this Func<T1, T2, TResult> fn) 
        => p1 => p2 => fn(p1, p2);
    
    public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn) 
        => p1 => p2 => p3 => fn(p1, p2, p3);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn) 
        => p1 => p2 => p3 => p4 => fn(p1, p2, p3, p4);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curry<T1, T2, T3, T4, T5, TResult>
            (this Func<T1, T2, T3, T4, T5, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => fn(p1, p2, p3, p4, p5);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curry<T1, T2, T3, T4, T5, T6, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => p6 => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => p6 => p7 => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => p6 => p7 => p8 => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => p6 => p7 => p8 => p9 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, TResult>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn) 
        => p1 => p2 => p3 => p4 => p5 => p6 => p7 => p8 => p9 => p10 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}