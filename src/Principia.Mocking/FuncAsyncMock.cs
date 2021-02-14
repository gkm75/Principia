using System;
using System.Threading.Tasks;

namespace Principia.Mocking
{
    public static class FuncAsyncMock
    {
        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<TReturn> Create<TReturn>() => new FuncAsyncInnerMock<TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<TReturn> Create<TReturn>(TReturn value) => new FuncAsyncInnerMock<TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<TReturn> Create<TReturn>(Func<Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<TReturn>(chainFuncAsync);


        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, TReturn> Create<T1, TReturn>() => new FuncAsyncInnerMock<T1, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, TReturn> Create<T1, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, TReturn> Create<T1, TReturn>(Func<T1, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, TReturn>(chainFuncAsync);


        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>() => new FuncAsyncInnerMock<T1, T2, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(Func<T1, T2, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, TReturn>(chainFuncAsync);


        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(Func<T1, T2, T3, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(chainFuncAsync);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>() => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>();

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(TReturn value) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(value);

        /// <summary>
        /// Creates an Async Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable async func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func which is implicitly in a Task</typeparam>
        /// <returns>FuncAsyncInnerMock</returns>
        public static FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TReturn>> chainFuncAsync) => new FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(chainFuncAsync);
    }

    #region FuncAsyncMock Inner Stubs

    public class FuncAsyncInnerMock<TReturn> : CallableMock
    {
        public Func<Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = () => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = () => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<Task<TReturn>> chainFuncAsync)
        {
            Object = () => {
                Exec();
                return chainFuncAsync.Invoke();
            };
        }
    }

    public class FuncAsyncInnerMock<T1, TReturn> : CallableMock
    {
        public Func<T1, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1) => {
                Exec();
                return chainFuncAsync.Invoke(p1);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, TReturn> : CallableMock
    {
        public Func<T1, T2, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, T5, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, T5, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4, p5);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, T5, T6, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4, p5, p6);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4, p5, p6, p7);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
    }

    public class FuncAsyncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TReturn>> Object { get; }

        internal FuncAsyncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return Task.FromResult<TReturn>(default);
            };
        }

        internal FuncAsyncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return Task.FromResult(value);
            };
        }

        internal FuncAsyncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Task<TReturn>> chainFuncAsync)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return chainFuncAsync.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
    }

    #endregion
}
