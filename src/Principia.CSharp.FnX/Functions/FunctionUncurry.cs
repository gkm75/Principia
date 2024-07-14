using System;

namespace Principia.CSharp.FnX.Functions;

public static partial class Function
{
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T, TResult> Uncurry<T, TResult>
            (this Func<Func<T, TResult>> fn) 
        => p => fn()(p);

    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, TResult> Uncurry<T1, T2, TResult>
            (this Func<T1, Func<T2, TResult>> fn)
        => (p1, p2) => fn(p1)(p2);

    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, TResult> Uncurry<T1, T2, T3, TResult>
            (this Func<T1, Func<T2, Func<T3, TResult>>> fn)
        => (p1, p2, p3) => fn(p1)(p2)(p3);

    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, TResult> Uncurry<T1, T2, T3, T4, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> fn)
        => (p1, p2, p3, p4) => fn(p1)(p2)(p3)(p4);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, TResult> Uncurry<T1, T2, T3, T4, T5, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> fn)
        => (p1, p2, p3, p4, p5) => fn(p1)(p2)(p3)(p4)(p5);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, T6, TResult> Uncurry<T1, T2, T3, T4, T5, T6, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> fn)
        => (p1, p2, p3, p4, p5, p6) => fn(p1)(p2)(p3)(p4)(p5)(p6);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> fn)
        => (p1, p2, p3, p4, p5, p6, p7) => fn(p1)(p2)(p3)(p4)(p5)(p6)(p7);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> fn)
        => (p1, p2, p3, p4, p5, p6, p7, p8) => fn(p1)(p2)(p3)(p4)(p5)(p6)(p7)(p8);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>> fn)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => fn(p1)(p2)(p3)(p4)(p5)(p6)(p7)(p8)(p9);
    
    /// <summary>
    /// Transforms a curried function into its uncurried form
    /// </summary>
    /// <param name="fn"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="T8"></typeparam>
    /// <typeparam name="T9"></typeparam>
    /// <typeparam name="T10"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
            (this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, TResult>>>>>>>>>> fn)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => fn(p1)(p2)(p3)(p4)(p5)(p6)(p7)(p8)(p9)(p10);
}