using System;

namespace Principia.Monads
{
    public static class MonadExtensions
    {
        public static Monad<T> Join<T>(this Monad<Monad<T>> monad)
            => monad.Value;

        public static Monad<U> Map<T, U>(this Monad<T> monad, Func<T, U> mapFn)
            => monad.Pure(mapFn(monad.Value));

        public static Monad<U> Applicative<T, U>(this Monad<T> monad, Monad<Func<T, U>> monadMapFn)
            => monad.Pure(monadMapFn.Value(monad.Value));
    }
}
