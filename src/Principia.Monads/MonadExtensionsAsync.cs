using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class MonadExtensionsAsync
    {
        public static Monad<Task<T>> JoinAsync<T>(Monad<Monad<Task<T>>> monad)
            => monad.Value;

        public static Task<Monad<T>> JoinAsync<T>(Monad<Task<Monad<T>>> monad)
            => monad.Value;
    }
}
