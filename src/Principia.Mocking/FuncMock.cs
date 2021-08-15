using System;

namespace Principia.Mocking
{
    public static class FuncMock
    {
        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<TReturn> Create<TReturn>() => new FuncInnerMock<TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<TReturn> Create<TReturn>(TReturn value) => new FuncInnerMock<TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<TReturn> Create<TReturn>(Func<TReturn> chainFunc) => new FuncInnerMock<TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>() => new FuncInnerMock<T1, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>(TReturn value) => new FuncInnerMock<T1, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>(Func<T1, TReturn> chainFunc) => new FuncInnerMock<T1, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>() => new FuncInnerMock<T1, T2, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(Func<T1, T2, TReturn> chainFunc) => new FuncInnerMock<T1, T2, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>() => new FuncInnerMock<T1, T2, T3, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn>(chainFunc);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>();

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. The value passed in this create
        /// method is returned by the proxy
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>(value);

        /// <summary>
        /// Creates a Func proxy which is verifyable after it is invoked. This override also
        /// accepts a callable func which is called in turn by the proxy itself
        /// </summary>
        /// <typeparam name="TReturn">The return type of the Func</typeparam>
        /// <returns>FuncInnerMock</returns>
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn>(chainFunc);
    }

    #region FuncMock Inner Stubs

    public class FuncInnerMock<TReturn> : CallableMock
    {
        public Func<TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = () => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = () => { 
                Exec(); 
                return value; 
            };
        }

        internal FuncInnerMock(Func<TReturn> chainFunc)
        {
            Object = () => {
                Exec();
                return chainFunc.Invoke();
            };
        }
    }

    public class FuncInnerMock<T1, TReturn> : CallableMock
    {
        public Func<T1, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, TReturn> chainFunc)
        {
            Object = (T1 p1) => {
                Exec();
                return chainFunc.Invoke(p1);
            };
        }
    }

    public class FuncInnerMock<T1, T2, TReturn> : CallableMock
    {
        public Func<T1, T2, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2) => {
                Exec();
                return chainFunc.Invoke(p1, p2);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            };
        }
    }
    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15);
            };
        }
    }

    public class FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> : CallableMock
    {
        public Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> Object { get; }

        internal FuncInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16) => {
                Exec();
                return default;
            };
        }

        internal FuncInnerMock(TReturn value)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16) => {
                Exec();
                return value;
            };
        }

        internal FuncInnerMock(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TReturn> chainFunc)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16) => {
                Exec();
                return chainFunc.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16);
            };
        }
    }

    #endregion
}
