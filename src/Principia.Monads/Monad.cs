using System;

namespace Principia.Monads
{
    public interface Monad<T>
    {
        T Value { get; }

        Monad<T> Unit();

        Monad<U> Bind<U>(Func<T, Monad<U>> bindFn);
    }
}
