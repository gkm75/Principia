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

        public static async Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> bindFn)
        {
            var result = await resultTask;
            return result.IsOk ? bindFn(result.Value) : result;
        }

        public static Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> bindFnTask)
            => result.IsOk ? bindFnTask(result.Value) : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> BindAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> bindFnTask)
        {
            var result = await resultTask;
            return result.IsOk
                    ? await bindFnTask(result.Value)
                    : result;
        }

        public static async Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, UOk> mapFn)
        {
            var result = await resultTask;
            return result.IsOk
                    ? Result.FromOr(mapFn(result.Value), result.FailValue)
                    : Result.Fail<UOk, TFail>(result.FailValue);
        }

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

        public static async Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Task<Func<TOk, UOk>> mapFnTask)
        {
            return result.IsOk
                    ? Result.FromOr((await mapFnTask)(result.Value), result.FailValue)
                    : Result.Fail<UOk, TFail>(result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> MapAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Task<Func<TOk, UOk>> mapFnTask)
        {
            await Task.WhenAll(resultTask, mapFnTask);
            return resultTask.Result.IsOk
                        ? Result.FromOr(mapFnTask.Result(resultTask.Result.Value), resultTask.Result.FailValue)
                        : Result.Fail<UOk, TFail>(resultTask.Result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, UOk>, TFail> resultMapFn)
        {
            var result = await resultTask;
            return result.IsOk && resultMapFn.IsOk
                               ? Result.FromOr(resultMapFn.Value(result.Value), result.FailValue)
                               : Result.Fail<UOk, TFail>(result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Task<Result<Func<TOk, UOk>, TFail>> resultMapFnTask)
        {
            var resultMapFn = await resultMapFnTask;
            return result.IsOk && resultMapFn.IsOk
                        ? Result.FromOr(resultMapFn.Value(result.Value), result.FailValue)
                        : Result.Fail<UOk, TFail>(result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Result<TOk, TFail> result, Result<Func<TOk, Task<UOk>>, TFail> resultMapFnAsync)
        {
            return result.IsOk && resultMapFnAsync.IsOk
                        ? Result.FromOr(await resultMapFnAsync.Value(result.Value), result.FailValue)
                        : Result.Fail<UOk, TFail>(result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Task<Result<Func<TOk, UOk>, TFail>> resultMapFnTask)
        {
            await Task.WhenAll(resultTask, resultMapFnTask);
            return resultTask.Result.IsOk && resultMapFnTask.Result.IsOk
                        ? Result.FromOr(resultMapFnTask.Result.Value(resultTask.Result.Value), resultTask.Result.FailValue)
                        : Result.Fail<UOk, TFail>(resultTask.Result.FailValue);
        }

        public static async Task<Result<UOk, TFail>> ApplicativeAsync<TOk, TFail, UOk>(this Task<Result<TOk, TFail>> resultTask, Result<Func<TOk, Task<UOk>>, TFail> resultMapFnAsync)
        {
            var result = await resultTask;
            return result.IsOk && resultMapFnAsync.IsOk
                        ? Result.FromOr(await resultMapFnAsync.Value(result.Value), result.FailValue)
                        : Result.Fail<UOk, TFail>(result.FailValue);
        }

        public static async Task<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action okAction)
        {
            var result = await resultTask;
            if (result.IsOk && okAction != null)
                okAction();

            return result;
        }

        public static async Task<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<TOk> okAction)
        {
            var result = await resultTask;
            if (result.IsOk && okAction != null)
                okAction(result.Value);

            return result;
        }

        public static async Task<Result<TOk, TFail>> WhenOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> okAction)
        {
            var result = await resultTask;
            if (result.IsOk && okAction != null)
                okAction(result);

            return result;
        }

        public static async Task<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action failAction)
        {
            var result = await resultTask;
            if (result.IsFail && failAction != null)
                failAction();

            return result;
        }

        public static async Task<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<TFail> failAction)
        {
            var result = await resultTask;
            if (result.IsFail && failAction != null)
                failAction(result.FailValue);

            return result;
        }

        public static async Task<Result<TOk, TFail>> WhenFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> failAction)
        {
            var result = await resultTask;
            if (result.IsFail && failAction != null)
                failAction(result);

            return result;
        }

        public static async Task<Result<TOk, TFail>> MatchAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<TOk> okAction, Action<TFail> failAction)
        {
            var result = await resultTask;
            if (result.IsOk && okAction != null)
                okAction(result.Value);
            else
                failAction?.Invoke(result.FailValue);

            return result;
        }

        public static async Task<Result<TOk, TFail>> MatchAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Action<Result<TOk, TFail>> okAction, Action<Result<TOk, TFail>> failAction)
        {
            var result = await resultTask;
            if (result.IsOk && okAction != null)
                okAction(result);
            else
                failAction?.Invoke(result);

            return result;
        }

        public static async Task<U> SubstituteAsync<TOk, TFail, U>(this Task<Result<TOk, TFail>> resultTask, U ok, U fail)
        {
            var result = await resultTask;
            return (result.IsOk) ? ok : fail;
        }

        public static async Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> okFn)
        {
            var result = await resultTask;
            return result.IsOk && okFn != null ? okFn() : result;
        }

        public static Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Task<Result<TOk, TFail>>> okFnAsync)
            => (result.IsOk && okFnAsync != null) ? okFnAsync() : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Task<Result<TOk, TFail>>> okFnAsync)
        {
            var result = await resultTask;
            return result.IsOk && okFnAsync != null ? await okFnAsync() : result;
        }

        public static Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> okFn)
            => resultTask.ContinueWith(task => task.Result.IsOk && okFn != null ? okFn(task.Result.Value) : task.Result);

        public static Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> okFnAsync)
            => (result.IsOk && okFnAsync != null) ? okFnAsync(result.Value) : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> okFnAsync)
        {
            var result = await resultTask;
            return result.IsOk && okFnAsync != null ? await okFnAsync(result.Value) : result;
        }

        public static Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<TOk, TFail>> okFn)
            => resultTask.ContinueWith(task => task.Result.IsOk && okFn != null ? okFn(task.Result) : task.Result);

        public static Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Task<Result<TOk, TFail>>> okFnAsync)
            => (result.IsOk && okFnAsync != null) ? okFnAsync(result) : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnOkAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Task<Result<TOk, TFail>>> okFnAsync)
        {
            var result = await resultTask;
            return result.IsOk && okFnAsync != null ? await okFnAsync(result) : result;
        }

        public static Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>> failFn)
            => resultTask.ContinueWith(task => task.Result.IsFail && failFn != null ? failFn() : task.Result);

        public static Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Task<Result<TOk, TFail>>> failFnAsync)
            => (result.IsFail && failFnAsync != null) ? failFnAsync() : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Task<Result<TOk, TFail>>> failFnAsync)
        {
            var result = await resultTask;
            return result.IsFail && failFnAsync != null ? await failFnAsync() : result;
        }

        public static async Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> failFn)
        {
            var result = await resultTask;
            return result.IsFail && failFn != null ? failFn(result.Value) : result;
        }

        public static Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> failFnAsync)
            => (result.IsFail && failFnAsync != null) ? failFnAsync(result.Value) : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> failFnAsync)
        {
            var result = await resultTask;
            return result.IsFail && failFnAsync != null ? await failFnAsync(result.Value) : result;
        }

        public static Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<TOk, TFail>> failFn)
            => resultTask.ContinueWith(task => task.Result.IsFail && failFn != null ? failFn(task.Result) : task.Result);

        public static Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Task<Result<TOk, TFail>>> failFnAsync)
            => (result.IsFail && failFnAsync != null) ? failFnAsync(result) : Task.FromResult(result);

        public static async Task<Result<TOk, TFail>> OnFailAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Task<Result<TOk, TFail>>> failFnAsync) 
            => (await resultTask).IsFail && failFnAsync != null ? await failFnAsync(await resultTask) : await resultTask;

        public static async Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<UOk>> okFnAsync, Func<Task<UOk>> failFnAsync)
            => (result.IsOk && okFnAsync != null) ? Result.Ok<UOk, TFail>(await okFnAsync(result.Value)) : Result.Ok<UOk, TFail>(await failFnAsync());

        public static Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Result<TOk, TFail> result, Func<Result<TOk, TFail>, Task<Result<UOk, TFail>>> okFnAsync, Func<Task<Result<UOk, TFail>>> failFnAsync)
            => (result.IsOk && okFnAsync != null) ? okFnAsync(result) : failFnAsync();

        public static async Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, UOk> okFn, Func<UOk> failFn)
        {
            if (okFn == null)
                return Result.Ok<UOk, TFail>(failFn());

            var result = await resultTask;
            if (result.IsFail)
                return Result.Ok<UOk, TFail>(failFn());

            return Result.Ok<UOk, TFail>(okFn(result.Value));
        }

        public static async Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Result<UOk, TFail>> okFn, Func<Result<UOk, TFail>> failFn)
        {
            if (okFn == null)
                return failFn();

            var result = await resultTask;
            if (result.IsFail)
                return failFn();

            return okFn(result);
        }

        public static async Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<UOk>> okFnAsync, Func<Task<UOk>> failFnAsync)
        {
            if (okFnAsync == null)
                return Result.Ok<UOk, TFail>(await  failFnAsync());

            var result = await resultTask;
            if(result.IsFail)
                return Result.Ok<UOk, TFail>(await failFnAsync());

            return Result.Ok<UOk, TFail>(await okFnAsync(result.Value));
        }

        public static async Task<Result<UOk, TFail>> BimapAsync<TOk, UOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<Result<TOk, TFail>, Task<Result<UOk, TFail>>> okFnAsync, Func<Task<Result<UOk, TFail>>> failFnAsync) 
            => okFnAsync == null ? await failFnAsync() : await ((await resultTask).IsOk ? okFnAsync(await resultTask) : failFnAsync());

        public static async Task<Result<TOk, TFail>> CombineAdditiveAsync<TOk, TFail>(this Result<TOk, TFail> result, Result<TOk, TFail> resultCombine, Func<TOk, TOk, Task<TOk>> additiveFnAsync)
        {
            if (result.IsFail)
                return resultCombine;

            if (resultCombine.IsFail)
                return result;

            return Result.Ok<TOk, TFail>(await additiveFnAsync(result.Value, resultCombine.Value));
        }

        public static async Task<Result<TOk, TFail>> CombineMultiplicativeAsync<TOk, TFail>(this Result<TOk, TFail> result, Result<TOk, TFail> resultCombine, Func<TOk, TOk, Task<TOk>> multiplicativeFnAsync)
        {
            if (result.IsFail)
                return result;

            if (resultCombine.IsFail)
                return resultCombine;

            return Result.Ok<TOk, TFail>(await multiplicativeFnAsync(result.Value, resultCombine.Value));
        }

        public static async Task<Result<TOk, TFail>> CombineAdditiveAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Task<Result<TOk, TFail>> resultCombineTask, Func<TOk, TOk, TOk> additiveFn)
        {
            await Task.WhenAll(resultTask, resultCombineTask);
                                
            if (resultTask.Result.IsFail)
                return resultCombineTask.Result;

            if (resultCombineTask.Result.IsFail)
                return resultTask.Result;

            return Result.Ok<TOk, TFail>(additiveFn(resultTask.Result.Value, resultCombineTask.Result.Value));
        }

        public static async Task<Result<TOk, TFail>> CombineMultiplicativeAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Task<Result<TOk, TFail>> resultCombineTask, Func<TOk, TOk, TOk> multiplicativeFn)
        {
            await Task.WhenAll(resultTask, resultCombineTask);
                             
            if (resultTask.Result.IsFail)
                return resultTask.Result;

            if (resultCombineTask.Result.IsFail)
                return resultCombineTask.Result;

            return Result.Ok<TOk, TFail>(multiplicativeFn(resultTask.Result.Value, resultCombineTask.Result.Value));
        }

        public static async Task<Result<TOk, TFail>> CombineAdditiveAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Task<Result<TOk, TFail>> resultCombineTask, Func<TOk, TOk, Task<TOk>> additiveFnAsync)
        {
            await Task.WhenAll(resultTask, resultCombineTask);

            if (resultTask.Result.IsFail)
                return resultCombineTask.Result;

            if (resultCombineTask.Result.IsFail)
                return resultTask.Result;

            return Result.Ok<TOk, TFail>(await additiveFnAsync(resultTask.Result.Value, resultCombineTask.Result.Value));
        }

        public static async Task<Result<TOk, TFail>> CombineMultiplicativeAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Task<Result<TOk, TFail>> resultCombineTask, Func<TOk, TOk, Task<TOk>> multiplicativeFnAsync)
        {
            await Task.WhenAll(resultTask, resultCombineTask);

            if (resultTask.Result.IsFail)
                return resultTask.Result;

            if (resultCombineTask.Result.IsFail)
                return resultCombineTask.Result;

            return Result.Ok<TOk, TFail>(await multiplicativeFnAsync(resultTask.Result.Value, resultCombineTask.Result.Value));
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, TOk> tryFn, TFail fail)
        {
            try
            {
                return Result.Ok<TOk, TFail>(tryFn((await resultTask).Value));
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, TOk> tryFn, Result<TOk, TFail> resultFail)
        {
            try
            {
                return Result.Ok<TOk, TFail>(tryFn((await resultTask).Value));
            }
            catch
            {
                return resultFail;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> tryFn, Result<TOk, TFail> resultFail)
        {
            try
            {
                return tryFn((await resultTask).Value);
            }
            catch
            {
                return resultFail;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Result<TOk, TFail>> tryFn, TFail fail)
        {
            try
            {
                return tryFn((await resultTask).Value);
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<TOk>> tryFnAsync, TFail fail)
        {
            try
            {
                return Result.Ok<TOk, TFail>(await tryFnAsync(result.Value));
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<TOk>> tryFn, Task<Result<TOk, TFail>> resultFailTask)
        {
            try
            {
                return Result.Ok<TOk, TFail>(await tryFn(result.Value));
            }
            catch
            {
                return await resultFailTask;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> tryFnAsync, Task<Result<TOk, TFail>> resultFailTask)
        {
            try
            {
                return await tryFnAsync(result.Value);
            }
            catch
            {
                return await resultFailTask;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Result<TOk, TFail> result, Func<TOk, Task<Result<TOk, TFail>>> tryFnAsync, TFail fail)
        {
            try
            {
                return await tryFnAsync(result.Value);
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<TOk>> tryFnAsync, TFail fail)
        {
            try
            {
                return Result.Ok<TOk, TFail>(await tryFnAsync((await resultTask).Value));
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<TOk>> tryFn, Task<Result<TOk, TFail>> resultFailTask)
        {
            try
            {
                return Result.Ok<TOk, TFail>(await tryFn((await resultTask).Value));
            }
            catch
            {
                return await resultFailTask;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> tryFnAsync, Task<Result<TOk, TFail>> resultFailTask)
        {
            try
            {
                return await tryFnAsync((await resultTask).Value);
            }
            catch
            {
                return await resultFailTask;
            }
        }

        public static async Task<Result<TOk, TFail>> TryAsync<TOk, TFail>(this Task<Result<TOk, TFail>> resultTask, Func<TOk, Task<Result<TOk, TFail>>> tryFnAsync, TFail fail)
        {
            try
            {
                return await tryFnAsync((await resultTask).Value);
            }
            catch
            {
                return Result.Fail<TOk, TFail>(fail);
            }
        }
    }
}
