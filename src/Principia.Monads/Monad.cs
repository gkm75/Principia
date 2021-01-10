using System;

namespace Principia.Monads
{
    public interface Monad<T>
    {
        T Value { get; }

        Monad<U> Pure<U>(U value);

        Monad<U> Bind<U>(Func<T, Monad<U>> bindFn);
    }
}
