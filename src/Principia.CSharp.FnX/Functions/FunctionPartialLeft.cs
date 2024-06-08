using System;

namespace Principia.CSharp.FnX;

public static partial class Function
{
    public static Func<TResult> PartialLeft<T, TResult>
            (this Func<T, TResult> fn, T p)
        => () => fn(p);
 
    public static Func<T1, TResult> PartialLeft<T1, T2, TResult>
            (this Func<T1, T2, TResult> fn, T2 p2)
        => p1 => fn(p1, p2);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, TResult>
        (this Func<T1, T2, T3, TResult> fn, T2 p2, T3 p3)
        => p1 => fn(p1, p2, p3);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T3 p3)
        => (p1, p2) => fn(p1, p2, p3);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T2 p2, T3 p3, T4 p4)
        => p1 => fn(p1, p2, p3, p4);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T3 p3, T4 p4)
        => (p1, p2) => fn(p1, p2, p3, p4);
    
    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T4 p4)
        => (p1, p2, p3) => fn(p1, p2, p3, p4);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5)
        => p1 => fn(p1, p2, p3, p4, p5);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T3 p3, T4 p4, T5 p5)
        => (p1, p2) => fn(p1, p2, p3, p4, p5);
    
    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T4 p4, T5 p5)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T5 p5)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        => p1 => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T3 p3, T4 p4, T5 p5, T6 p6)
        => (p1, p2) => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T4 p4, T5 p5, T6 p6)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T5 p5, T6 p6)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5, p6);
    
    public static Func<T1, T2, T3, T4, T5, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T6 p6)
        => (p1, p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5, p6);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        => p1 => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        => (p1, p2) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T4 p4, T5 p5, T6 p6, T7 p7)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T5 p5, T6 p6, T7 p7)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, T2, T3, T4, T5, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T6 p6, T7 p7)
        => (p1, p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, T2, T3, T4, T5, T6, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T7 p7)
        => (p1, p2, p3, p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        => p1 => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        => (p1, p2) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T5 p5, T6 p6, T7 p7, T8 p8)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, T2, T3, T4, T5, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T6 p6, T7 p7, T8 p8)
        => (p1, p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5, p6, p7, p8);

    public static Func<T1, T2, T3, T4, T5, T6, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T7 p7, T8 p8)
        => (p1, p2, p3, p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T8 p8)
        => (p1, p2, p3, p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7, p8);

    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        => p1 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        => (p1, p2) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    public static Func<T1, T2, T3, T4, T5, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T6 p6, T7 p7, T8 p8, T9 p9)
        => (p1, p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    public static Func<T1, T2, T3, T4, T5, T6, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T7 p7, T8 p8, T9 p9)
        => (p1, p2, p3, p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T8 p8, T9 p9)
        => (p1, p2, p3, p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T9 p9)
        => (p1, p2, p3, p4, p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
  
    public static Func<T1, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        => p1 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        => (p1, p2) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

    public static Func<T1, T2, T3, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        => (p1, p2, p3) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, T3, T4, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T5 p5, T6 p6, T7 p7,T8 p8, T9 p9, T10 p10)
        => (p1, p2, p3, p4) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

    public static Func<T1, T2, T3, T4, T5, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)
        => (p1, p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, T3, T4, T5, T6, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T7 p7, T8 p8, T9 p9, T10 p10)
        => (p1, p2, p3, p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T8 p8, T9 p9, T10 p10)
        => (p1, p2, p3, p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T9 p9, T10 p10)
        => (p1, p2, p3, p4, p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> PartialLeft<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T10 p10)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}