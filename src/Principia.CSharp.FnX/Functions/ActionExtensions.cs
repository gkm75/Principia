using System;

namespace Principia.CSharp.FnX.Functions;

public static class ActionExtensions
{
    public static Func<Unit> ToFunc(this Action action)
        => () =>
            {
                action(); 
                return Unit.Value;
            };
    
    public static Func<T1, Unit> ToFunc<T1>(this Action<T1> action)
        => p1 =>
        {
            action(p1); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
        => (p1, p2) =>
        {
            action(p1, p2); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action)
        => (p1, p2, p3) =>
        {
            action(p1, p2, p3); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        => (p1, p2, p3, p4) =>
        {
            action(p1, p2, p3, p4); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
        => (p1, p2, p3, p4, p5) =>
        {
            action(p1, p2, p3, p4, p5); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
        => (p1, p2, p3, p4, p5, p6) =>
        {
            action(p1, p2, p3, p4, p5, p6); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
        => (p1, p2, p3, p4, p5, p6, p7) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8, p9); 
            return Unit.Value;
        };
    
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10); 
            return Unit.Value;
        };

    public static Action ToAction(this Func<Unit> func)
        => () => func();
    
    public static Action<T1> ToAction<T1>(this Func<T1, Unit> func)
        => p1 => func(p1); 

    public static Action<T1, T2> ToAction<T1, T2>(this Func<T1, T2, Unit> func)
        => (p1, p2) => func(p1, p2); 

    public static Action<T1, T2, T3> ToAction<T1, T2, T3>(this Func<T1, T2, T3, Unit> func)
        => (p1, p2, p3) => func(p1, p2, p3); 

    public static Action<T1, T2, T3, T4> ToAction<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Unit> func)
        => (p1, p2, p3, p4) => func(p1, p2, p3, p4); 

    public static Action<T1, T2, T3, T4, T5> ToAction<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5, Unit> func)
        => (p1, p2, p3, p4, p5) => func(p1, p2, p3, p4, p5); 

    public static Action<T1, T2, T3, T4, T5, T6> ToAction<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6, Unit> func)
        => (p1, p2, p3, p4, p5, p6) => func(p1, p2, p3, p4, p5, p6);

    public static Action<T1, T2, T3, T4, T5, T6, T7> ToAction<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7) => func(p1, p2, p3, p4, p5, p6, p7);

    public static Action<T1, T2, T3, T4, T5, T6, T7, T8> ToAction<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8) => func(p1, p2, p3, p4, p5, p6, p7, p8);
    
    public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => func(p1, p2, p3, p4, p5, p6, p7, p8, p9); 
    
    public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => func(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}
