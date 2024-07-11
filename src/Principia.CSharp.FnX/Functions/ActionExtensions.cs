using System;

namespace Principia.CSharp.FnX.Functions;

/// <summary>
/// Extension class to transform Actions to Functions and vice-versa
/// </summary>
public static class ActionExtensions
{
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<Unit> ToFunc(this Action action)
        => () =>
            {
                action(); 
                return Unit.Value;
            };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, Unit> ToFunc<T1>(this Action<T1> action)
        => p1 =>
        {
            action(p1); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> action)
        => (p1, p2) =>
        {
            action(p1, p2); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> action)
        => (p1, p2, p3) =>
        {
            action(p1, p2, p3); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        => (p1, p2, p3, p4) =>
        {
            action(p1, p2, p3, p4); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> action)
        => (p1, p2, p3, p4, p5) =>
        {
            action(p1, p2, p3, p4, p5); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> action)
        => (p1, p2, p3, p4, p5, p6) =>
        {
            action(p1, p2, p3, p4, p5, p6); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> action)
        => (p1, p2, p3, p4, p5, p6, p7) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <typeparam name="T9">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8, p9); 
            return Unit.Value;
        };
    
    /// <summary>
    /// Transforms an action into a function which returns Unit
    /// </summary>
    /// <param name="action">The action to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <typeparam name="T9">Type of parameter</typeparam>
    /// <typeparam name="T10">Type of parameter</typeparam>
    /// <returns>A function which calls the action and returns Unit</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
        {
            action(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10); 
            return Unit.Value;
        };

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action ToAction(this Func<Unit> func)
        => () => func();
    
    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1> ToAction<T1>(this Func<T1, Unit> func)
        => p1 => func(p1); 

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2> ToAction<T1, T2>(this Func<T1, T2, Unit> func)
        => (p1, p2) => func(p1, p2); 

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3> ToAction<T1, T2, T3>(this Func<T1, T2, T3, Unit> func)
        => (p1, p2, p3) => func(p1, p2, p3); 

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4> ToAction<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, Unit> func)
        => (p1, p2, p3, p4) => func(p1, p2, p3, p4); 
    
    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5> ToAction<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5, Unit> func)
        => (p1, p2, p3, p4, p5) => func(p1, p2, p3, p4, p5); 

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5, T6> ToAction<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6, Unit> func)
        => (p1, p2, p3, p4, p5, p6) => func(p1, p2, p3, p4, p5, p6);

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5, T6, T7> ToAction<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7) => func(p1, p2, p3, p4, p5, p6, p7);

    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5, T6, T7, T8> ToAction<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8) => func(p1, p2, p3, p4, p5, p6, p7, p8);
    
    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <typeparam name="T9">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => func(p1, p2, p3, p4, p5, p6, p7, p8, p9); 
    
    /// <summary>
    /// Transforms the passed func into an action
    /// </summary>
    /// <param name="func">The func to be transformed</param>
    /// <typeparam name="T1">Type of parameter</typeparam>
    /// <typeparam name="T2">Type of parameter</typeparam>
    /// <typeparam name="T3">Type of parameter</typeparam>
    /// <typeparam name="T4">Type of parameter</typeparam>
    /// <typeparam name="T5">Type of parameter</typeparam>
    /// <typeparam name="T6">Type of parameter</typeparam>
    /// <typeparam name="T7">Type of parameter</typeparam>
    /// <typeparam name="T8">Type of parameter</typeparam>
    /// <typeparam name="T9">Type of parameter</typeparam>
    /// <typeparam name="T10">Type of parameter</typeparam>
    /// <returns>An action which calls the passed func and does not return anything</returns>
    public static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> func)
        => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => func(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
}
