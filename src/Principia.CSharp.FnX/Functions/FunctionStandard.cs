using System;

namespace Principia.CSharp.FnX.Functions;

public static partial class Function
{
    public static T Id<T>(T value) => value;
    
    public static Func<T> Constant<T>(T value) => () => value;
    
    public static T DefaultOf<T>() => default;
    
    public static T DefaultOf<T>(T _) => default;
    
    public static Func<T> Default<T>() => () => default;
    
    public static Func<T> Default<T>(T value) => () => default;
    
    public static Func<T, TReturn> ToDefault<T, TReturn>() => _ => default;
    
    public static bool IsOdd(sbyte n) => (n & 1) == 1;
    
    public static bool IsOdd(short n) => (n & 1) == 1;
    
    public static bool IsOdd(int n) => (n & 1) == 1;
    
    public static bool IsOdd(long n) => (n & 1) == 1;
    
    public static bool IsEven(sbyte n) => (n & 1) == 0;
    
    public static bool IsEven(short n) => (n & 1) == 0;
    
    public static bool IsEven(int n) => (n & 1) == 0;
    
    public static bool IsEven(long n) => (n & 1) == 0;
    
    public static bool IsOdd(byte n) => (n & 1) == 1;
    
    public static bool IsOdd(ushort n) => (n & 1) == 1;
    
    public static bool IsOdd(uint n) => (n & 1) == 1;
    
    public static bool IsOdd(ulong n) => (n & 1) == 1;
    
    public static bool IsEven(byte n) => (n & 1) == 0;
    
    public static bool IsEven(ushort n) => (n & 1) == 0;
    
    public static bool IsEven(uint n) => (n & 1) == 0;
    
    public static bool IsEven(ulong n) => (n & 1) == 0;

    public static bool EpsilonEquals(float f1, float f2, float epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
    
    public static bool EpsilonEquals(double f1, double f2, double epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
    
    public static bool EpsilonEquals(decimal f1, decimal f2, decimal epsilon) => f2 >= (f1 - epsilon) && f2 <= (f1 + epsilon);
}