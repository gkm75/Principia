using System;

namespace Principia.CSharp.FnX.Monads;

public interface IMonad
{
    bool HasValue { get; }
}

public interface IMonad<T> : IMonad
{
    IMonad<U> Bind<U>(Func<T, IMonad<U>> bindFn);
}
