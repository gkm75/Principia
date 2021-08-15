using System;

namespace Principia.Mocking
{
    public static class ActionMock
    {
        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock Create() => new ActionInnerMock();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock Create(Action chainAction) => new ActionInnerMock(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1> Create<T1>() => new ActionInnerMock<T1>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1> Create<T1>(Action<T1> chainAction) => new ActionInnerMock<T1>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2> Create<T1, T2>() => new ActionInnerMock<T1, T2>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2> Create<T1, T2>(Action<T1, T2> chainAction) => new ActionInnerMock<T1, T2>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3> Create<T1, T2, T3>() => new ActionInnerMock<T1, T2, T3>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> chainAction) => new ActionInnerMock<T1, T2, T3>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4> Create<T1, T2, T3, T4>() => new ActionInnerMock<T1, T2, T3, T4>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> chainAction) => new ActionInnerMock<T1, T2, T3, T4>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>() => new ActionInnerMock<T1, T2, T3, T4, T5>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9>(chainAction);

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(chainAction);

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(chainAction);


        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>();

        /// <summary>
        /// Creates an Action proxy which is verifyable after it is invoked. This override also
        /// accepts a callable action which is called in turn by the proxy itself
        /// </summary>
        /// <returns>ActionInnerMock</returns>
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(chainAction);


    }

    #region ActionMock Inner Stubs

    public class ActionInnerMock : CallableMock
    {
        public Action Object { get; }

        internal ActionInnerMock()
        {
            Object = () => Exec();
        }

        internal ActionInnerMock(Action chainAction)
        {
            Object = () =>
            {
                Exec();
                chainAction?.Invoke();
            };
        }
    }

    public class ActionInnerMock<T1> : CallableMock
    {
        public Action<T1> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1) => Exec();
        }

        internal ActionInnerMock(Action<T1> chainAction)
        {
            Object = (T1 p1) =>
            {
                Exec();
                chainAction?.Invoke(p1);
            };
        }
    }

    public class ActionInnerMock<T1, T2> : CallableMock
    {
        public Action<T1, T2> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2> chainAction)
        {
            Object = (T1 p1, T2 p2) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3> : CallableMock
    {
        public Action<T1, T2, T3> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4> : CallableMock
    {
        public Action<T1, T2, T3, T4> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                    p10, p11, p12);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12, T13> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                    p10, p11, p12, p13);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12, T13, T14> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                    p10, p11, p12, p13, p14);
            };
        }
    }

    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12, T13, T14, T15> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                    p10, p11, p12, p13, p14, p15);
            };
        }
    }
    public class ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> : CallableMock
    {
        public Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> Object { get; }

        internal ActionInnerMock()
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16) => Exec();
        }

        internal ActionInnerMock(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9,
            T10, T11, T12, T13, T14, T15, T16> chainAction)
        {
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9,
                T10 p10, T11 p11, T12 p12, T13 p13, T14 p14, T15 p15, T16 p16) =>
            {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9,
                    p10, p11, p12, p13, p14, p15, p16);
            };
        }
    }

    #endregion
}
