using System;
using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class MonadExtensionsAsync
    {
        public static Monad<Task<T>> JoinAsync<T>(Monad<Monad<Task<T>>> monad)
            => monad.Value;

        public static Task<Monad<T>> JoinAsync<T>(Monad<Task<Monad<T>>> monad)
            => monad.Value;

        public static async Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Func<T, U> mapFn)
        {
            var monad = (await monadTask);
            return monad.Pure(mapFn(monad.Value));
        }

        public static async Task<Monad<U>> MapAsync<T, U>(this Monad<T> monad, Func<T, Task<U>> mapFnAsync) 
            => monad.Pure(await mapFnAsync(monad.Value));

        public static async Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Func<T, Task<U>> mapFnAsync)
        {
            var monad = await monadTask;
            return monad.Pure(await mapFnAsync(monad.Value));
        }

        public static async Task<Monad<U>> MapAsync<T, U>(this Monad<T> monad, Task<Func<T, U>> mapFnTask)
        {
            var mapFn = await mapFnTask;
            return monad.Pure(mapFn(monad.Value));
        }

        public static async Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Task<Func<T, U>> mapFnTask)
        {
            await Task.WhenAll(monadTask, mapFnTask);
            return monadTask.Result.Pure(mapFnTask.Result(monadTask.Result.Value));
        }

        public static async Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Monad<Func<T, U>> monadMapFn)
        {
            var monad = await monadTask;
            return monad.Pure(monadMapFn.Value(monad.Value));
        }

        public static async Task<Monad<U>> ApplicativeAsync<T, U>(this Monad<T> monad, Monad<Func<T, Task<U>>> monadMapFnAsync)
        {
            var result = await monadMapFnAsync.Value(monad.Value);
            return monad.Pure(result);
        }

        public static async Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Monad<Func<T, Task<U>>> monadMapFnAsync)
        {
            var monad = await monadTask;
            var result = await monadMapFnAsync.Value(monad.Value);
            return monad.Pure(result);
        }

        public static async Task<Monad<U>> ApplicativeAsync<T, U>(this Monad<T> monad, Task<Monad<Func<T, U>>> monadMapFnTask)
        {
            var mapFn = await monadMapFnTask;
            return monad.Pure(mapFn.Value(monad.Value));
        }

        public static async Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Task<Monad<Func<T, U>>> monadMapFnTask)
        {
            await Task.WhenAll(monadTask, monadMapFnTask);
            return monadTask.Result.Pure(monadMapFnTask.Result.Value(monadTask.Result.Value));
        }
    }
}

