using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Principia.CSharp.FnX.Functions;

/// <summary>
/// Exposes some convenient standard Functions
/// </summary>
public static class Standard
{
    /// <summary>
    /// The identity function
    /// </summary>
    /// <param name="value">The passed value</param>
    /// <typeparam name="T">Type of the value</typeparam>
    /// <returns>The passed value/object instance back</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Id<T>(T value) => value;
    
    /// <summary>
    /// Accepts a value and creates a function which always returns this value
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>A new function which always returns the passed value</returns>
    public static Func<T> Constant<T>(T value) => () => value;
    
    /// <summary>
    /// Returns the default value of the type parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>default</returns>
    public static T DefaultOf<T>() => default;
    
    /// <summary>
    /// Returns the default value of the type of the passed parameter
    /// </summary>
    /// <param name="_"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>default</returns>
    public static T DefaultOf<T>(T _) => default;
    
    /// <summary>
    /// Returns a function which in turn returns the default value of the type parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Function which returns the default</returns>
    public static Func<T> Default<T>() => () => default;
    
    /// <summary>
    /// Returns a function which in turn returns the default value of the type parameter
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>Function which returns the default</returns>
    public static Func<T> Default<T>(T value) => () => default;
    
    /// <summary>
    /// Creates and returns a function which accepts a parameter and returns the default value of its type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TReturn"></typeparam>
    /// <returns>A function which returns the default type of its parameter</returns>
    public static Func<T, TReturn> ToDefault<T, TReturn>() => _ => default;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(sbyte n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(short n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(int n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(long n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(sbyte n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(short n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(int n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(long n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(byte n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(ushort n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(uint n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is odd
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is odd</returns>
    public static bool IsOdd(ulong n) => (n & 1) == 1;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(byte n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(ushort n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(uint n) => (n & 1) == 0;
    
    /// <summary>
    /// Tests if the passed number n is even
    /// </summary>
    /// <param name="n"></param>
    /// <returns>True if n is even</returns>
    public static bool IsEven(ulong n) => (n & 1) == 0;
    
    /// <summary>
    /// An equality function to test if a number is equal to another within an epsilon range
    /// </summary>
    /// <param name="v1">The first value to compare</param>
    /// <param name="v2">The second value to compare</param>
    /// <param name="epsilon">The interval of the range</param>
    /// <returns>True if the values are equal within the range</returns>
    public static bool EpsilonEquals<T>(T v1, T v2, T epsilon) 
            where T : ISubtractionOperators<T, T, T>, IAdditionOperators<T, T, T>, IComparisonOperators<T, T, bool>
        => v2 >= (v1 - epsilon) && v2 <= (v1 + epsilon);


    /// <summary>
    /// Accepts a list of values and returns the first which is not null
    /// </summary>
    /// <param name="inputs"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Coalesce<T>(params T[] inputs)
    {
        foreach (var value in inputs)
        {
            if (value != null)
            {
                return value;
            }
        }

        return default;
    }
    
    /// <summary>
    /// Accepts a list of functions and returns the first which value after execution is not null
    /// </summary>
    /// <param name="inputFns"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Coalesce<T>(params Func<T>[] inputFns)
    {
        foreach (var fn in inputFns)
        {
            if (fn == null)
            {
                continue;
            }
            
            var value = fn();
            if (value != null)
            {
                return value;
            }
        }

        return default;
    }
}
