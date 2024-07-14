using System;

namespace Principia.CSharp.FnX.Functions;

public static partial class Function
{
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns>A function with partially applied parameters</returns>
    public static Func<TResult> Partial<T, TResult>
            (this Func<T, TResult> fn, T p)
        => () => fn(p);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, TResult> Partial<T1, T2, TResult>
            (this Func<T1, T2, TResult> fn, T1 p1)
        => p2 => fn(p1, p2);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T3, TResult> Partial<T1, T2, T3, TResult>
        (this Func<T1, T2, T3, TResult> fn, T1 p1, T2 p2)
        => p3 => fn(p1, p2, p3);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, T3, TResult> Partial<T1, T2, T3, TResult>
            (this Func<T1, T2, T3, TResult> fn, T1 p1)
        => (p2, p3) => fn(p1, p2, p3);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T4, TResult> Partial<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T1 p1, T2 p2, T3 p3)
        => p4 => fn(p1, p2, p3, p4);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T3, T4, TResult> Partial<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T1 p1, T2 p2)
        => (p3, p4) => fn(p1, p2, p3, p4);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, T3, T4, TResult> Partial<T1, T2, T3, T4, TResult>
            (this Func<T1, T2, T3, T4, TResult> fn, T1 p1)
        => (p2, p3, p4) => fn(p1, p2, p3, p4);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T5, TResult> Partial<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => p5 => fn(p1, p2, p3, p4, p5);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T4, T5, TResult> Partial<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5) => fn(p1, p2, p3, p4, p5);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T3, T4, T5, TResult> Partial<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5) => fn(p1, p2, p3, p4, p5);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, T3, T4,T5, TResult> Partial<T1, T2, T3, T4, T5, TResult>
        (this Func<T1, T2, T3, T4, T5, TResult> fn, T1 p1)
        => (p2, p3, p4, p5) => fn(p1, p2, p3, p4, p5);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T6, TResult> Partial<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        => p6 => fn(p1, p2, p3, p4, p5, p6);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T5, T6, TResult> Partial<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => (p5, p6) => fn(p1, p2, p3, p4, p5, p6);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T4, T5, T6, TResult> Partial<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T3, T4, T5, T6, TResult> Partial<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5, p6) => fn(p1, p2, p3, p4, p5, p6);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, T3, T4, T5, T6, TResult> Partial<T1, T2, T3, T4, T5, T6, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, TResult> fn, T1 p1)
        => (p2, p3, p4, p5,p6) => fn(p1, p2, p3, p4, p5, p6);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        => p7 => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T6, T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        => (p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T5, T6, T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => (p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T4, T5, T6, T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T3, T4, T5, T6, T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    /// <typeparam name="T7"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static Func<T2, T3, T4, T5, T6, T7, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, TResult> fn, T1 p1)
        => (p2, p3, p4, p5, p6, p7) => fn(p1, p2, p3, p4, p5, p6, p7);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
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
    public static Func<T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        => p8 => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
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
    public static Func<T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        => (p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
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
    public static Func<T6, T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
            (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        => (p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
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
    public static Func<T5, T6, T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => (p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
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
    public static Func<T4, T5, T6, T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
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
    public static Func<T3, T4, T5, T6, T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
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
    public static Func<T2, T3, T4, T5, T6, T7, T8, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> fn, T1 p1)
        => (p2, p3, p4, p5, p6, p7, p8) => fn(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
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
    public static Func<T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        => p9 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
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
    public static Func<T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        => (p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
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
    public static Func<T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        => (p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
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
    public static Func<T6, T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        => (p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
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
    public static Func<T5, T6, T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => (p5, p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
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
    public static Func<T4, T5, T6, T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5, p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
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
    public static Func<T3, T4, T5, T6, T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5, p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
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
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> fn, T1 p1)
        => (p2, p3, p4, p5, p6, p7, p8, p9) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
    /// <param name="p9"></param>
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
    public static Func<T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)
        => p10 => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
    /// <param name="p8"></param>
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
    public static Func<T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)
        => (p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
    /// <param name="p7"></param>
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
    public static Func<T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)
        => (p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
    /// <param name="p6"></param>
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
    public static Func<T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)
        => (p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
    /// <param name="p5"></param>
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
    public static Func<T6, T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)
        => (p6, p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p4"></param>
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
    public static Func<T5, T6, T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3, T4 p4)
        => (p5, p6, p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
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
    public static Func<T4, T5, T6, T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2, T3 p3)
        => (p4, p5, p6, p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
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
    public static Func<T3, T4, T5, T6, T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1, T2 p2)
        => (p3, p4, p5, p6, p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
    
    /// <summary>
    /// Partial application (from the rightmost parameter) for the function passed as parameter
    /// </summary>
    /// <param name="fn"></param>
    /// <param name="p1"></param>
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
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>
        (this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> fn, T1 p1)
        => (p2, p3, p4, p5, p6, p7, p8, p9, p10) => fn(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}