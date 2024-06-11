using System;

namespace Principia.CSharp.FnX.Monads;

public interface IMonad
{
    bool HasValue { get; }
}

public interface IMonad<T> : IMonad
{
    T Reduce { get; }
    T ReduceOr(T orValue);
    T ReduceOr(Func<T> orValueFn);
    IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn);
}

