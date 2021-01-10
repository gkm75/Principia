using System;
using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class ResultExtensionsAsync
    {
        public static async Task<Monad<TOk>> PureAsync<TOk, TFail>(this Task<TOk> task)
            => Result.Ok<TOk, TFail>(await task);

        public static Result<Task<TOk>, TFail> JoinAsync<TOk, TFail>(this Result<Result<Task<TOk>, TFail>, TFail> result)
            => result.IsOk ? result.Value : Result.Fail<Task<TOk>, TFail>(result.FailValue);

        public static Task<Result<TOk, TFail>> JoinAsync<TOk, TFail>(this Result<Task<Result<TOk, TFail>>, TFail> result)
            => result.IsOk ? result.Value : Task.FromResult(Result.Fail<TOk, TFail>(result.FailValue));

        public static Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> bindFn)
            => resultTask.ContinueWith(
                task => task.Result.IsOk ? bindFn(task.Result.Value) : task.Result,
                TaskContinuationOptions.OnlyOnRanToCompletion);
 
        public static Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> bindFnTask)
            => result.IsOk ? bindFnTask(result.Value) : Task.FromResult(result);

        public static Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> bindFnTask)
            => resultTask
                .ContinueWith(task => task.Result.IsOk
                    ? bindFnTask(task.Result.Value)
                    : task, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => task.Result.Result);

        public static Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, UOk> mapFn)
            => resultTask.ContinueWith(
                task => task.Result.IsOk 
                        ? Result.FromOr(mapFn(task.Result.Value), task.Result.FailValue) 
                        : Result.Fail<UOk,TFail>(task.Result.FailValue),
                TaskContinuationOptions.OnlyOnRanToCompletion);

        public static async Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Func<TOk, Task<UOk>> mapFnAsync)
            => result.IsOk
                ? Result.FromOr(await mapFnAsync(result.Value), result.FailValue)
                : Result.Fail<UOk, TFail>(result.FailValue);

        public static async Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<UOk>> mapFnAsync)
        {
            var result = await resultTask;
            return result.IsOk
                ? Result.FromOr(await mapFnAsync(result.Value), result.FailValue)
                : Result.Fail<UOk, TFail>(result.FailValue); 
        }

        public static Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Task<Func<TOk, UOk>> mapFnTask)
            => result.IsOk
                ? mapFnTask.ContinueWith(task => Result.FromOr(task.Result(result.Value), result.FailValue), TaskContinuationOptions.OnlyOnRanToCompletion)
                : Task.FromResult(Result.Fail<UOk, TFail>(result.FailValue));

        public static Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Task<Func<TOk, UOk>> mapFnTask)
            => Task.WhenAll(resultTask, mapFnTask)
                .ContinueWith(_ => resultTask.Result.IsOk
                    ? Result.FromOr(mapFnTask.Result(resultTask.Result.Value), resultTask.Result.FailValue)
                    : Result.Fail<UOk, TFail>(resultTask.Result.FailValue), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, UOk>, TFail> resultMapFn)
            => resultTask.ContinueWith( 
                task => task.Result.IsOk && resultMapFn.IsOk
                    ? Result.FromOr(resultMapFn.Value(task.Result.Value), task.Result.FailValue)
                    : Result.Fail<UOk, TFail>(task.Result.FailValue), TaskContinuationOptions.OnlyOnRanToCompletion);

        public static Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Task<Result<Func<TOk, UOk>, TFail>> resultMapFnTask)
            => resultMapFnTask.ContinueWith(
                fnTask => result.IsOk && fnTask.Result.IsOk
                    ? Result.FromOr(fnTask.Result.Value(result.Value), result.FailValue)
                    : Result.Fail<UOk, TFail>(result.FailValue), TaskContinuationOptions.OnlyOnRanToCompletion);
        
        public static Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Result<Func<TOk, Task<UOk>>, TFail> resultMapFnAsync)
            => result.IsOk && resultMapFnAsync.IsOk
                    ? resultMapFnAsync.Value(result.Value).ContinueWith(task => Result.FromOr(task.Result, result.FailValue), TaskContinuationOptions.OnlyOnRanToCompletion)
                    : Task.FromResult(Result.Fail<UOk, TFail>(result.FailValue));

        public static Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Task<Result<Func<TOk, UOk>, TFail>> resultMapFnTask)
            => Task.WhenAll(resultTask, resultMapFnTask).ContinueWith(
                _ => resultTask.Result.IsOk && resultMapFnTask.Result.IsOk
                    ? Result.FromOr(resultMapFnTask.Result.Value(resultTask.Result.Value), resultTask.Result.FailValue)
                    : Result.Fail<UOk, TFail>(resultTask.Result.FailValue));

        public static Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, Task<UOk>>, TFail> resultMapFnAsync)
            => resultTask
                .ContinueWith(
                    task => task.Result.IsOk && resultMapFnAsync.IsOk
                        ? resultMapFnAsync.Value(task.Result.Value).ContinueWith(innerTask => Result.FromOr(innerTask.Result, task.Result.FailValue))
                        : Task.FromResult(Result.Fail<UOk, TFail>(task.Result.FailValue)), TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(task => task.Result.Result, TaskContinuationOptions.OnlyOnRanToCompletion);
    }
}
