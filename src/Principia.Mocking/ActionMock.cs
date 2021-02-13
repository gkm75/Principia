using System;

namespace Principia.Mocking
{
    public static class ActionMock
    {
        public static ActionInnerMock Create() => new ActionInnerMock();
        public static ActionInnerMock Create(Action chainAction) => new ActionInnerMock(chainAction);

        public static ActionInnerMock<T1> Create<T1>() => new ActionInnerMock<T1>();
        public static ActionInnerMock<T1> Create<T1>(Action<T1> chainAction) => new ActionInnerMock<T1>(chainAction);

        public static ActionInnerMock<T1, T2> Create<T1, T2>() => new ActionInnerMock<T1, T2>();
        public static ActionInnerMock<T1, T2> Create<T1, T2>(Action<T1, T2> chainAction) => new ActionInnerMock<T1, T2>(chainAction);

        public static ActionInnerMock<T1, T2, T3> Create<T1, T2, T3>() => new ActionInnerMock<T1, T2, T3>();
        public static ActionInnerMock<T1, T2, T3> Create<T1, T2, T3>(Action<T1, T2, T3> chainAction) => new ActionInnerMock<T1, T2, T3>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4> Create<T1, T2, T3, T4>() => new ActionInnerMock<T1, T2, T3, T4>();
        public static ActionInnerMock<T1, T2, T3, T4> Create<T1, T2, T3, T4>(Action<T1, T2, T3, T4> chainAction) => new ActionInnerMock<T1, T2, T3, T4>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>() => new ActionInnerMock<T1, T2, T3, T4, T5>();
        public static ActionInnerMock<T1, T2, T3, T4, T5> Create<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6>();
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6> Create<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7>();
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7> Create<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8>();
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8> Create<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8>(chainAction);

        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>() => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9>();
        public static ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> chainAction) => new ActionInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9>(chainAction);
    }


    public class ActionInnerMock : CallableMock
    {
        public Action Object { get; }

        internal ActionInnerMock()
        {
            Object = () => Exec();
        }

        internal ActionInnerMock(Action chainAction)
        {
            Object = () => { 
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
            Object = (T1 p1) => {
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
            Object = (T1 p1, T2 p2) => {
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
            Object = (T1 p1, T2 p2, T3 p3) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => {
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
            Object = (T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => {
                Exec();
                chainAction?.Invoke(p1, p2, p3, p4, p5, p6, p7, p8, p9);
            };
        }
    }
}
