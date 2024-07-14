using System;

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
    /// An equality function to test if a float number is equal to another within an epsilon range
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <param name="epsilon"></param>
    /// <returns></returns>
    public static bool EpsilonEquals(float f1, float f2, float epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
    
    /// <summary>
    /// An equality function to test if a float number is equal to another within an epsilon range
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <param name="epsilon"></param>
    /// <returns></returns>
    public static bool EpsilonEquals(double f1, double f2, double epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
    
    /// <summary>
    /// An equality function to test if a float number is equal to another within an epsilon range
    /// </summary>
    /// <param name="f1"></param>
    /// <param name="f2"></param>
    /// <param name="epsilon"></param>
    /// <returns></returns>
    public static bool EpsilonEquals(decimal f1, decimal f2, decimal epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
}