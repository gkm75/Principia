﻿using System;

namespace Principia.Mocking
{
    /// <summary>
    /// This class returns predicate-functions to test the number against a predefined value
    /// </summary>
    public static class Times
    {
        public static Func<int, TimesResult> Never => Exactly(0);
            
        public static Func<int, TimesResult> Once => Exactly(1);

        public static Func<int, TimesResult> Twice => Exactly(2);

        public static Func<int, TimesResult> Exactly(int t) =>
            (n => n == t
                ? TimesResult.Create()
                : TimesResult.Create($"Expected number of times to be {t}, but was {n}"));

        public static Func<int, TimesResult> Between(int lower, int upper) =>
            (n => n >= lower && n <= upper 
                ? TimesResult.Create()
                : TimesResult.Create($"Expected number of times to be between {lower} and {upper}, but was {n}"));

        public static Func<int, TimesResult> NotBetween(int lower, int upper) =>
            (n => n < lower && n > upper
                ? TimesResult.Create()
                : TimesResult.Create($"Expected number of times not to be between {lower} and {upper}, but was {n}"));

        public static Func<int, TimesResult> AtLeast(int t) =>
            (n => n >= t
                ? TimesResult.Create()
                : TimesResult.Create($"Expected number of times to be at least {t}, but was {n}"));

        public static Func<int, TimesResult> AtMost(int t) =>
            (n => n <= t
                ? TimesResult.Create()
                : TimesResult.Create($"Expected number of times to be at most {t}, but was {n}"));

        public static Func<int, TimesResult> AtLeastOnce => AtLeast(1);

        public static Func<int, TimesResult> AtMostOnce => AtMost(1);

        public static Func<int, TimesResult> AtLeastTwice => AtLeast(2);

        public static Func<int, TimesResult> AtMostTwice => AtMost(2);
    }


    /// <summary>
    /// This is the resulting object returned by the Times functions after evaluating the precidate
    /// </summary>
    public struct TimesResult
    {
        public bool IsError { get; }
        public string Message { get; }

        private TimesResult(bool isError, string message)
        {
            IsError = isError;
            Message = message;
        }

        public static TimesResult Create()
            => new TimesResult(false, null);

        public static TimesResult Create(string message)
            => new TimesResult(true, message);

        public static TimesResult Create(bool isError, string message)
            => new TimesResult(isError, message);
    }
}
