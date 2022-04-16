using System;
using System.Threading.Tasks;

namespace Principia.Monads
{
    public static class OptionExtensionsAsync
    {
        public static async Task<Monad<T>> PureAsync<T>(this Task<T> task)
            => Option.From(await task);

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

        public static async Task<Option<T>> BindAsync<T>(this Task<Option<T>> optionTask, Func<T, Option<T>> bindFn)
        {
            var option = await optionTask;
            return bindFn(option.Value);
        }

        public static Task<Option<T>> BindAsync<T>(this Option<T> option, Func<T, Task<Option<T>>> bindFnTask)
            => option.IsSome ? bindFnTask(option.Value) : Task.FromResult(Option.None<T>());

        public static async Task<Option<T>> BindAsync<T>(this Task<Option<T>> optionTask, Func<T, Task<Option<T>>> bindFnAsync)
        {
            var option = await optionTask;
            return option.IsSome ? await bindFnAsync(option.Value) : Option.None<T>();
        }
 
        public static async Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> mapFn)
        {
            var option = await optionTask;
            return option.IsSome ? Option.From(mapFn(option.Value)) : Option.None<U>();
        }

        public static async Task<Option<U>> MapAsync<T, U>(this Option<T> option, Func<T, Task<U>> mapFnAsync) 
            => option.IsSome ? Option.From(await mapFnAsync(option.Value)) : Option.None<U>();

        public static async Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, Task<U>> mapFnAsync)
        {
            var option = await optionTask;
            return option.IsSome ? Option.From(await mapFnAsync(option.Value)) : Option.None<U>();
        }

        public static async Task<Option<U>> MapAsync<T, U>(this Option<T> option, Task<Func<T, U>> mapFnTask)
        {
            return option.IsSome
                    ? Option.From((await mapFnTask)(option.Value))
                    : Option.None<U>();
        }

        public static async Task<Option<U>> MapAsync<T, U>(this Task<Option<T>> optionTask, Task<Func<T, U>> mapFnTask)
        {
            var option = await optionTask;
            return option.IsSome
                    ? Option.From((await mapFnTask)(option.Value))
                    : Option.None<U>();
        }

        public static async Task<Option<U>> SwitchMap<T, U>(this Task<Option<T>> optionTask, Func<U> mapFn)
        {
            var option = await optionTask;
            return option.IsNone ? Option.From(mapFn()) : Option.None<U>();
        }

        public static async Task<Option<U>> SwitchMap<T, U>(this Option<T> option, Func<Task<U>> mapFnAsync)
            => option.IsNone ? Option.From(await mapFnAsync()) : Option.None<U>();

        public static async Task<Option<U>> SwitchMap<T, U>(this Task<Option<T>> optionTask, Func<Task<U>> mapFnAsync)
        {
            var option = await optionTask;
            return option.IsNone ? Option.From(await mapFnAsync()) : Option.None<U>();
        }

        public static async Task<Option<U>> SwitchMap<T, U>(this Option<T> option, Task<Func<U>> mapFnTask) 
            => option.IsNone ? Option.From((await mapFnTask)()) : Option.None<U>();

        public static async Task<Option<U>> SwitchMap<T, U>(this Task<Option<T>> optionTask, Task<Func<U>> mapFnTask)
        {
            var option = await optionTask;
            return option.IsNone ? Option.From((await mapFnTask)()) : Option.None<U>();
        }

        public static async Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Option<Func<T, U>> optionMapFn)
        {
            var option = await optionTask;
            return option.IsSome
                        ? Option.From(optionMapFn.Value(option.Value))
                        : Option.None<U>();
        }

        public static async Task<Option<U>> ApplicativeAsync<T, U>(this Option<T> option, Option<Func<T, Task<U>>> optionMapFnAsync)
        {
            return option.IsSome && optionMapFnAsync.IsSome
                           ? Option.From(await optionMapFnAsync.Value(option.Value))
                           : Option.None<U>();
        }

        public static async Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Option<Func<T, Task<U>>> optionMapFnAsync)
        {
            var option = await optionTask;
            return option.IsSome && optionMapFnAsync.IsSome
                    ? Option.From(await optionMapFnAsync.Value(option.Value))
                    : Option.None<U>();
        }

        public static async Task<Option<U>> ApplicativeAsync<T, U>(this Option<T> option, Task<Option<Func<T, U>>> optionMapFnTask)
        {
            var optionMapFn = await optionMapFnTask;
            return option.IsSome && optionMapFn.IsSome
                    ? Option.From(optionMapFn.Value(option.Value))
                    : Option.None<U>();
        }

        public static async Task<Option<U>> ApplicativeAsync<T, U>(this Task<Option<T>> optionTask, Task<Option<Func<T, U>>> optionMapFnTask)
        {
            await Task.WhenAll(optionTask, optionMapFnTask);
            return optionTask.Result.IsSome && optionMapFnTask.Result.IsSome
                    ? Option.From(optionMapFnTask.Result.Value(optionTask.Result.Value))
                    : Option.None<U>();
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action action)
        {
            var option = await optionTask;
            if (option.IsSome)
                action?.Invoke();

            return option; 
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action<T> action)
        {
            var option = await optionTask;
            if (option.IsSome)
                action?.Invoke(option.Value);

            return option;
        }

        public static async Task<Option<T>> WhenSomeAsync<T>(this Task<Option<T>> optionTask, Action<Option<T>> action)
        {
            var option = await optionTask;
            if (option.IsSome)
                action?.Invoke(option);

            return option;

        }

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

        public static async Task<Option<T>> WhenNoneAsync<T>(this Task<Option<T>> optionTask, Action action)
        {
            var option = await optionTask;
            if (option.IsNone)
                action?.Invoke();

            return option;
        }

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

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action actionSome, Action actionNone)
        {
            var option = await optionTask;
            if (option.IsSome)
                actionSome?.Invoke();
            else
                actionNone?.Invoke();

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action<T> actionSome, Action actionNone)
        {
            var option = await optionTask;
            if (option.IsSome)
                actionSome?.Invoke(option.Value);
            else
                actionNone?.Invoke();

            return option;
        }

        public static async Task<Option<T>> MatchAsync<T>(this Task<Option<T>> optionTask, Action<Option<T>> actionSome, Action actionNone)
        {
            var option = await optionTask;
            if (option.IsSome)
                actionSome?.Invoke(option);
            else
                actionNone?.Invoke();

            return option;
        }

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

        public static async Task<U> SubstituteAsync<T, U>(this Task<Option<T>> optionTask, U some, U none)
        {
            var option = await optionTask;
            return (option.IsSome) 
                ? some 
                : none;
        }

        public static async Task<U> SubstituteAsync<T, U>(this Task<Option<T>> optionTask, Task<U> some, Task<U> none)
        {
            var option = await optionTask;
            return await ((option.IsSome) ? some : none);
        }

        public static async Task<Option<T>> OnNoneAsync<T>(this Task<Option<T>> optionTask, Func<T> noneFn)
        {
            var option = await optionTask;
            return (option.IsNone && noneFn != null) ? Option.From(noneFn()) : option;
        }

        public static async Task<Option<T>> OnNoneAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>> noneFn)
        {
            var option = await optionTask;
            return (option.IsNone && noneFn != null) ? noneFn() : option;
        }

        public static async Task<Option<T>> OnNoneAsync<T>(this Option<T> option, Func<Task<T>> noneAsyncFn)
            => (option.IsNone && noneAsyncFn != null) ? Option.From(await noneAsyncFn()) : option;

        public static async Task<Option<T>> OnNoneAsync<T>(this Option<T> option, Func<Task<Option<T>>> noneAsyncFn)
            => (option.IsNone && noneAsyncFn != null) ? (await noneAsyncFn()) : option;

        public static async Task<Option<T>> OnSomeAsync<T>(this Task<Option<T>> optionTask, Func<T, T> someFn)
        {
            var option = await optionTask;
            return (option.IsSome && someFn != null) ? Option.From(someFn(option.Value)) : option;
        }

        public static async Task<Option<T>> OnSomeAsync<T>(this Task<Option<T>> optionTask, Func<Option<T>, Option<T>> someFn)
        {
            var option = await optionTask;
            return (option.IsSome && someFn != null) ? (someFn(option)) : option;
        }
          

        public static async Task<Option<T>> OnSomeAsync<T>(this Option<T> option, Func<T, Task<T>> someAsyncFn)
            => (option.IsSome && someAsyncFn != null) ? Option.From(await someAsyncFn(option.Value)) : option;

        public static async Task<Option<T>> OnSomeAsync<T>(this Option<T> option, Func<Option<T>, Task<Option<T>>> someAsyncFn)
            => (option.IsSome && someAsyncFn != null) ? (await someAsyncFn(option)) : option;

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> someFn, Func<U> noneFn)
        {
            var option = await optionTask;
            return Option.From(option.IsSome
                ? someFn(option.Value)
                : noneFn());
        }

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<Option<T>, Option<U>> someFn, Func<Option<U>> noneFn)
        {
            var option = await optionTask;
            return option.IsSome
                ? someFn?.Invoke(option) ?? Option.None<U>()
                : noneFn?.Invoke() ?? Option.None<U>();
        }

        public static async Task<Option<U>> BimapAsync<T, U>(this Option<T> option, Func<T, Task<U>> someAsyncFn, Func<Task<U>> noneAsyncFn)
            => (option.IsSome && someAsyncFn != null) 
                ? Option.From(await someAsyncFn(option.Value)) 
                : ((noneAsyncFn == null) ? Option.None<U>() : Option.From(await noneAsyncFn()));

        public static Task<Option<U>> BimapAsync<T, U>(this Option<T> option, Func<Option<T>, Task<Option<U>>> someAsyncFn, Func<Task<Option<U>>> noneAsyncFn)
            => (option.IsSome && someAsyncFn != null) 
                ? someAsyncFn(option) 
                : ((noneAsyncFn == null) ? Task.FromResult(Option.None<U>()) : noneAsyncFn());

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<T, Task<U>> someAsyncFn, Func<Task<U>> noneAsyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && someAsyncFn != null)
                return Option.From(await someAsyncFn(option.Value)); 
            
            return ((noneAsyncFn == null) ? Option.None<U>() : Option.From(await noneAsyncFn()));
        }

        public static async Task<Option<U>> BimapAsync<T, U>(this Task<Option<T>> optionTask, Func<Option<T>, Task<Option<U>>> someAsyncFn, Func<Task<Option<U>>> noneAsyncFn)
        {
            var option = await optionTask;
            if (option.IsSome && someAsyncFn != null)
                return await someAsyncFn(option);

            return ((noneAsyncFn == null) ? Option.None<U>() : await noneAsyncFn());
        }

        public static async Task<Option<T>> CombineAdditiveAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, T> additiveFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone)
                return optionTask.Result;

            if (optionTask.Result.IsNone)
                return optionAddTask.Result;

            return Option.From(additiveFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static async Task<Option<T>> CombineAdditiveAsync<T>(this Option<T> option, Option<T> optionAdd, Func<T, T, Task<T>> additiveAsyncFn)
        {
            if (optionAdd.IsNone)
                return option;

            if (option.IsNone)
                return optionAdd;

            return Option.From(await additiveAsyncFn(option.Value, optionAdd.Value));
        }

        public static async Task<Option<T>> CombineAdditiveAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, Task<T>> additiveAsyncFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone)
                return optionTask.Result;

            if (optionTask.Result.IsNone)
                return optionAddTask.Result;

            return Option.From(await additiveAsyncFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static async Task<Option<T>> CombineMultiplicativeAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, T> multiplicativeFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone || optionTask.Result.IsNone)
                return Option.None<T>();

            return Option.From(multiplicativeFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static async Task<Option<T>> CombineMultiplicativeAsync<T>(this Option<T> option, Option<T> optionAdd, Func<T, T, Task<T>> multiplicativeAsyncFn)
        {
            if (optionAdd.IsNone || option.IsNone)
                return Option.None<T>();

            return Option.From(await multiplicativeAsyncFn(option.Value, optionAdd.Value));
        }

        public static async Task<Option<T>> CombineMultiplicativeAsync<T>(this Task<Option<T>> optionTask, Task<Option<T>> optionAddTask, Func<T, T, Task<T>> multiplicativeAsyncFn)
        {
            await Task.WhenAll(optionTask, optionAddTask);
            if (optionAddTask.Result.IsNone || optionTask.Result.IsNone)
                return Option.None<T>();

            return Option.From(await multiplicativeAsyncFn(optionTask.Result.Value, optionAddTask.Result.Value));
        }

        public static async Task <Option<U>> TryAsync<T, U>(this Task<Option<T>> optionTask, Func<T, U> tryFn)
        {
            var option = await optionTask;
            try
            {
                return Option.From(tryFn(option.Value));
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
                return Option.From(await tryAsyncFn(option.Value));
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
                return Option.From(await tryAsyncFn(option.Value));
            }
            catch
            {
                return Option.None<U>();
            }
        }
    }
}
