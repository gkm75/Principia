using System;
using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class OptionExtensionsAsync
    {
        public static async Task<Monad<T>> PureAsync<T>(this Task<T> task)
            => Option.Some(await task);

        public static Task<T> ValueOrAsync<T>(this Option<Task<T>> option, T fallback)
            => option.IsSome ? option.Value : Task.FromResult(fallback);

        public static Task<T> ValueOrNullAsync<T>(this Option<Task<T>> option) where T : class
            => option.IsSome ? option.Value : Task.FromResult<T>(null);

        public static Task<T> ValueOrDefaultAsync<T>(this Option<Task<T>> option)
            => option.IsSome ? option.Value : Task.FromResult<T>(default);

        public static Option<Task<T>> JoinAsync<T>(this Option<Option<Task<T>>> option)
            => option.IsSome ? option.Value : Option.None<Task<T>>();

        public static Task<Option<T>> JoinAsync<T>(this Option<Task<Option<T>>> option)
            => option.IsSome ? option.Value : Task.FromResult(Option.None<T>());

        public static Task<Option<T>> BindAsync<T>(this Task<Option<T>> optionTask, Func<T, Option<T>> bindFn)
            => optionTask.ContinueWith(task => task.Result.IsSome ? bindFn(task.Result.Value) : task.Result, 
                TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> BindAsync<T>(this Option<T> option, Func<T, Task<Option<T>>> bindFnTask)
            => option.IsSome ? bindFnTask(option.Value) : Task.FromResult(Option.None<T>());

        public static Task<Option<T>> BindAsync<T>(this Task<Option<T>> optionTask, Func<T, Task<Option<T>>> bindFnAsync)
            => optionTask
                .ContinueWith(
                    task => task.Result.IsSome ? bindFnAsync(task.Result.Value) : optionTask,
                    TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith( task => task.Result.Result, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> mapFn)
            => optionTask.ContinueWith(
                task => task.Result.IsSome 
                    ? Option.From(mapFn(task.Result.Value)) 
                    : Option.None<U>(), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> MapAsync<T, U>(this Option<T> option, Func<T, Task<U>> mapFnAsync)
            => option.IsSome 
                ? mapFnAsync(option.Value).ContinueWith(task => Option.From(task.Result), TaskContinuationOptions.OnlyOnRanToCompletion) 
                : Task.FromResult(Option.None<U>());

        public static Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, Task<U>> mapFnAsync)
            => optionTask
                .ContinueWith(
                    task => task.Result.IsSome
                        ? mapFnAsync(task.Result.Value).ContinueWith(inner => Option.From(inner.Result), TaskContinuationOptions.OnlyOnRanToCompletion)
                        : Task.FromResult(Option.None<U>()), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => task.Result.Result, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> MapAsync<T, U>(this Option<T> option, Task<Func<T, U>> mapFnTask)
                => option.IsSome 
                    ? mapFnTask.ContinueWith(task => Option.From(task.Result(option.Value)), TaskContinuationOptions.OnlyOnRanToCompletion)
                    : Task.FromResult(Option.None<U>());

        public static Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Task<Func<T, U>> mapFnTask)
            => Task.WhenAll(optionTask, mapFnTask)
                .ContinueWith(
                    _ => optionTask.Result.IsSome
                        ? Option.From(mapFnTask.Result(optionTask.Result.Value))
                        : Option.None<U>(), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Option<Func<T, U>> optionMapFn)
            => optionTask
                .ContinueWith(task => task.Result.IsSome
                    ? Option.From(optionMapFn.Value(task.Result.Value))
                    : Option.None<U>(), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> ApplicativeAsync<T, U>(this Option<T> option, Option<Func<T, Task<U>>> optionMapFnAsync)
            => option.IsSome && optionMapFnAsync.IsSome 
                ? optionMapFnAsync.Value(option.Value).ContinueWith(inner => Option.From(inner.Result)) 
                : Task.FromResult(Option.None<U>());

        public static Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Option<Func<T, Task<U>>> optionMapFnAsync)
            => optionTask
                .ContinueWith(
                    task => task.Result.IsSome
                        ? optionMapFnAsync.Value(task.Result.Value).ContinueWith(inner => Option.From(inner.Result))
                        : Task.FromResult(Option.None<U>()), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => task.Result.Result, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> ApplicativeAsync<T, U>(this Option<T> option, Task<Option<Func<T, U>>> optionMapFnTask)
            => option.IsSome
                ? optionMapFnTask
                    .ContinueWith(task => task.Result.IsSome 
                        ? Option.From(task.Result.Value(option.Value)) 
                        : Option.None<U>(), TaskContinuationOptions.OnlyOnRanToCompletion)
                : Task.FromResult(Option.None<U>());

        public static Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Task<Option<Func<T, U>>> optionMapFnTask)
            => Task.WhenAll(optionTask, optionMapFnTask)
                .ContinueWith(
                    _ => optionTask.Result.IsSome && optionMapFnTask.Result.IsSome
                        ? Option.From(optionMapFnTask.Result.Value(optionTask.Result.Value))
                        : Option.None<U>(), TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
