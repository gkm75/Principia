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

        public static Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Func<T, U> mapFn)
            => monadTask
                .ContinueWith(task => task.Result.Pure(mapFn(task.Result.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> MapAsync<T, U>(this Monad<T> monad, Func<T, Task<U>> mapFnAsync)
            => mapFnAsync(monad.Value)
                .ContinueWith(task => monad.Pure(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        
        public static Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Func<T, Task<U>> mapFnAsync)
            => monadTask
            .ContinueWith(task => mapFnAsync(task.Result.Value), TaskContinuationOptions.OnlyOnRanToCompletion)
            .ContinueWith(task => monadTask.Result.Pure(task.Result.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> MapAsync<T, U>(this Monad<T> monad, Task<Func<T, U>> mapFnTask)
            => mapFnTask
                .ContinueWith(task => monad.Pure(task.Result(monad.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);
        
        public static Task<Monad<U>> MapAsync<T, U>(this Task<Monad<T>> monadTask, Task<Func<T, U>> mapFnTask)
            => Task.WhenAll(monadTask, mapFnTask)
                .ContinueWith(_ => monadTask.Result.Pure(mapFnTask.Result(monadTask.Result.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Monad<Func<T, U>> monadMapFn)
            => monadTask
                .ContinueWith(task => task.Result.Pure(monadMapFn.Value(task.Result.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> ApplicativeAsync<T, U>(this Monad<T> monad, Monad<Func<T, Task<U>>> monadMapFnAsync)
            => monadMapFnAsync
                .Value(monad.Value)
                .ContinueWith(task => monad.Pure(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Monad<Func<T, Task<U>>> monadMapFnAsync)
            => monadTask
                .ContinueWith(task => monadMapFnAsync.Value(task.Result.Value), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => monadTask.Result.Pure(task.Result.Result), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> ApplicativeAsync<T, U>(this Monad<T> monad, Task<Monad<Func<T, U>>> monadMapFnTask)
            => monadMapFnTask
                .ContinueWith(task => monad.Pure(task.Result.Value(monad.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Monad<U>> ApplicativeAsync<T, U>(this Task<Monad<T>> monadTask, Task<Monad<Func<T, U>>> monadMapFnTask)
            => Task.WhenAll(monadTask, monadMapFnTask)
                .ContinueWith(_ => monadTask.Result.Pure(monadMapFnTask.Result.Value(monadTask.Result.Value)), TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
