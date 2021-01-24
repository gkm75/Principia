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
                .ContinueWith(task => task.Result.Result, TaskContinuationOptions.OnlyOnRanToCompletion);

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

        public static Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action action)
            => optionTask.ContinueWith(
                task =>
                {
                    if (task.Result.IsSome)
                        action?.Invoke();

                    return task.Result;
                }
                , TaskContinuationOptions.OnlyOnRanToCompletion);


        public static Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action<T> action)
            => optionTask.ContinueWith(
                task =>
                {
                    if (task.Result.IsSome)
                        action?.Invoke(task.Result.Value);

                    return task.Result;
                }
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action<Option<T>> action)
        => optionTask.ContinueWith(
                task =>
                {
                    if (task.Result.IsSome)
                        action?.Invoke(task.Result);

                    return task.Result;
                }
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> WhenSomeAsync<T>(this Option<T> option, Func<Task> asyncFn)
        {
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke();

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Option<T> option, Func<T, Task> asyncFn)
        {
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke(option.Value);

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Option<T> option, Func<Option<T>, Task> asyncFn)
        {
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke(option);

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Func<Task> asyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke();

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Func<T, Task> asyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke(option.Value);

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>, Task> asyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && asyncFn != null)
                await asyncFn?.Invoke(option);

            return option;
        }

        public static Task<Option<T>> WhenNoneAsync<T>(this Task<Option<T>> optionTask, Action action)
            => optionTask.ContinueWith(
                task =>
                {
                    if (task.Result.IsNone)
                        action?.Invoke();

                    return task.Result;
                }
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> WhenNoneAsync<T>(this Option<T> option, Func<Task> asyncFn)
        {
            if (option.IsNone && asyncFn != null)
                await asyncFn();

            return option;
        }

        public static async Task<Option<T>> WhenNoneAsync<T>(this Task<Option<T>> optionTask, Func<Task> asyncFn)
        {
            var option = await optionTask;
            if (option.IsNone && asyncFn != null)
                await asyncFn();

            return option;
        }


        public static Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action actionSome, Action actionNone)
            => optionTask.ContinueWith(task => {
                if (task.Result.IsSome)
                    actionSome?.Invoke();
                else
                    actionNone?.Invoke();

                return task.Result;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action<T> actionSome, Action actionNone)
            => optionTask.ContinueWith(task => {
                if (task.Result.IsSome)
                    actionSome?.Invoke(task.Result.Value);
                else
                    actionNone?.Invoke();

                return task.Result;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action<Option<T>> actionSome, Action actionNone)
            => optionTask.ContinueWith(task => {
                if (task.Result.IsSome)
                    actionSome?.Invoke(task.Result);
                else
                    actionNone?.Invoke();

                return task.Result;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> MatchAsync<T>(this Option<T> option, Func<Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            await ((option.IsSome)
                ? someAsyncFn?.Invoke()
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Option<T> option, Func<T, Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            await ((option.IsSome)
                ? someAsyncFn?.Invoke(option.Value)
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Option<T> option, Func<Option<T>, Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            await ((option.IsSome)
                ? someAsyncFn?.Invoke(option)
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Func<Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            var option = await optionTask;
            await ((option.IsSome)
                ? someAsyncFn?.Invoke()
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Func<T, Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            var option = await optionTask;
            await ((option.IsSome)
                ? someAsyncFn?.Invoke(option.Value)
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>, Task> someAsyncFn, Func<Task> noneAsyncFn)
        {
            var option = await optionTask;
            await ((option.IsSome)
                ? someAsyncFn?.Invoke(option)
                : noneAsyncFn?.Invoke());

            return option;
        }

        public static Task<Option<T>> OnNoneAsync<T>(this Task<Option<T>> optionTask, Func<T> noneFn)
            => optionTask.ContinueWith(
                task => (task.Result.IsNone && noneFn != null) ? Option.Some(noneFn()) : task.Result
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> OnNoneAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>> noneFn)
            => optionTask.ContinueWith(
                task => (task.Result.IsNone && noneFn != null) ? noneFn() : task.Result
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> OnNoneAsync<T>(this Option<T> option, Func<Task<T>> noneAsyncFn)
            => (option.IsNone && noneAsyncFn != null) ? Option.Some(await noneAsyncFn()) : option;

        public static async Task<Option<T>> OnNoneAsync<T>(this Option<T> option, Func<Task<Option<T>>> noneAsyncFn)
            => (option.IsNone && noneAsyncFn != null) ? (await noneAsyncFn()) : option;

        public static Task<Option<T>> OnSomeAsync<T>(this Task<Option<T>> optionTask, Func<T, T> someFn)
            => optionTask.ContinueWith(
                task => (task.Result.IsSome && someFn != null) ? Option.Some(someFn(task.Result.Value)) : task.Result
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<T>> OnSomeAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>, Option<T>> someFn)
            => optionTask.ContinueWith(
                task => (task.Result.IsSome && someFn != null) ? (someFn(task.Result)) : task.Result
                , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> OnSomeAsync<T>(this Option<T> option, Func<T, Task<T>> someAsyncFn)
            => (option.IsSome && someAsyncFn != null) ? Option.Some(await someAsyncFn(option.Value)) : option;

        public static async Task<Option<T>> OnSomeAsync<T>(this Option<T> option, Func<Option<T>, Task<Option<T>>> someAsyncFn)
            => (option.IsSome && someAsyncFn != null) ? (await someAsyncFn(option)) : option;

        public static Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> someFn, Func<U> noneFn)
            => optionTask.ContinueWith(
                task => (task.Result.IsSome && someFn != null)
                        ? Option.Some(someFn(task.Result.Value))
                        : (noneFn == null) ? Option.None<U>() : Option.Some(noneFn())
                    , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<Option<T>, Option<U>> someFn, Func<Option<U>> noneFn)
            => optionTask.ContinueWith(
                    task => (task.Result.IsSome && someFn != null)
                                ? someFn(task.Result)
                                : (noneFn == null) ? Option.None<U>() : noneFn()
                            , TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<U>> BimapAsync<T, U>(this Option<T> option, Func<T, Task<U>> someAsyncFn, Func<Task<U>> noneAsyncFn)
            => (option.IsSome && someAsyncFn != null) 
                ? Option.Some(await someAsyncFn(option.Value)) 
                : ((noneAsyncFn == null) ? Option.None<U>() : Option.Some(await noneAsyncFn()));
        

        public static Task<Option<U>> BimapAsync<T, U>(this Option<T> option, Func<Option<T>, Task<Option<U>>> someAsyncFn, Func<Task<Option<U>>> noneAsyncFn)
            => (option.IsSome && someAsyncFn != null) 
                ? someAsyncFn(option) 
                : ((noneAsyncFn == null) ? Task.FromResult(Option.None<U>()) : noneAsyncFn());

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, Task<U>> someAsyncFn, Func<Task<U>> noneAsyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && someAsyncFn != null)
                return Option.Some(await someAsyncFn(option.Value)); 
            
            return ((noneAsyncFn == null) ? Option.None<U>() : Option.Some(await noneAsyncFn()));
        }

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<Option<T>, Task<Option<U>>> someAsyncFn, Func<Task<Option<U>>> noneAsyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && someAsyncFn != null)
                return await someAsyncFn(option);

            return ((noneAsyncFn == null) ? Option.None<U>() : await noneAsyncFn());
        }

        public static Task<Option<T>> CombineAdditiveAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, T> additiveFn)
            => Task.WhenAll(optionTask, optionAddTask)
                .ContinueWith(
                    _ =>
                    {
                        if (optionAddTask.Result.IsNone)
                            return optionTask.Result;

                        if (optionTask.Result.IsNone)
                            return optionAddTask.Result;

                        return Option.Some(additiveFn(optionTask.Result.Value, optionAddTask.Result.Value));
                    }, TaskContinuationOptions.OnlyOnRanToCompletion );

        public static async Task<Option<T>> CombineAdditiveAsync<T>(this Option<T> option, Option<T> optionAdd, Func<T, T, Task<T>> additiveAsyncFn)
        {
            if (optionAdd.IsNone)
                return option;

            if (option.IsNone)
                return optionAdd;

            return Option.Some(await additiveAsyncFn(option.Value, optionAdd.Value));
        }

        public static async Task<Option<T>> CombineAdditiveAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, Task<T>> additiveAsyncFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone)
                return optionTask.Result;

            if (optionTask.Result.IsNone)
                return optionAddTask.Result;

            return Option.Some(await additiveAsyncFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static Task<Option<T>> CombineMultiplicativeAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, T> multiplicativeFn)
        => Task.WhenAll(optionTask, optionAddTask)
                .ContinueWith(
                    _ =>
                    {
                        if (optionAddTask.Result.IsNone || optionTask.Result.IsNone)
                            return Option.None<T>();

                        return Option.Some(multiplicativeFn(optionTask.Result.Value, optionAddTask.Result.Value));
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Option<T>> CombineMultiplicativeAsync<T>(this Option<T> option, Option<T> optionAdd, Func<T, T, Task<T>> multiplicativeAsyncFn)
        {
            if (optionAdd.IsNone || option.IsNone)
                return Option.None<T>();

            return Option.Some(await multiplicativeAsyncFn(option.Value, optionAdd.Value));
        }

        public static async Task<Option<T>> CombineMultiplicativeAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, Task<T>> multiplicativeAsyncFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone || optionTask.Result.IsNone)
                return Option.None<T>();

            return Option.Some(await multiplicativeAsyncFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static async Task <Option<U>> TryAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> tryFn)
        {
            var option = await optionTask;
            try
            {
                return Option.Some(tryFn(option.Value));
            }
            catch
            {
                return Option.None<U>();
            }
        }

        public static async Task<Option<U>> TryAsync<T, U>(this Option<T> option, Func<T, Task<U>> tryAsyncFn)
        {
            try
            {
                return Option.Some(await tryAsyncFn(option.Value));
            }
            catch
            {
                return Option.None<U>();
            }
        }

        public static async Task<Option<U>> TryAsync<T, U>(this Task<Option<T>> optionTask, Func<T, Task<U>> tryAsyncFn)
        {
            var option = await optionTask;
            try
            {
                return Option.Some(await tryAsyncFn(option.Value));
            }
            catch
            {
                return Option.None<U>();
            }
        }
    }
}
