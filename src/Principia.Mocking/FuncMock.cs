using System;

namespace Principia.Mocking
{
    public static class FuncMock
    {
        public static FuncInnerMock<TReturn> Create<TReturn>() => new FuncInnerMock<TReturn>();
        public static FuncInnerMock<TReturn> Create<TReturn>(TReturn value) => new FuncInnerMock<TReturn>(value);
        public static FuncInnerMock<TReturn> Create<TReturn>(Func<TReturn> chainFunc) => new FuncInnerMock<TReturn>(chainFunc);
        
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>() => new FuncInnerMock<T1, TReturn>();
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>(TReturn value) => new FuncInnerMock<T1, TReturn>(value);
        public static FuncInnerMock<T1, TReturn> Create<T1, TReturn>(Func<T1, TReturn> chainFunc) => new FuncInnerMock<T1, TReturn>(chainFunc);
        
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>() => new FuncInnerMock<T1, T2, TReturn>();
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, TReturn>(value);
        public static FuncInnerMock<T1, T2, TReturn> Create<T1, T2, TReturn>(Func<T1, T2, TReturn> chainFunc) => new FuncInnerMock<T1, T2, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>() => new FuncInnerMock<T1, T2, T3, TReturn>();
        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, TReturn> Create<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, TReturn> Create<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, T5, TReturn> Create<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn> Create<T1, T2, T3, T4, T5, T6, TReturn>(Func<T1, T2, T3, T4, T5, T6, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, TReturn>(chainFunc);

        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>() => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>();
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(TReturn value) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(value);
        public static FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> Create<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn> chainFunc) => new FuncInnerMock<T1, T2, T3, T4, T5, T6, T7, T8, T9, TReturn>(chainFunc);
    }


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
}
