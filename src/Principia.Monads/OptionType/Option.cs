using System;

namespace Principia.Monads
{
    public struct Option<T> : Monad<T>, IEquatable<Option<T>>
    {
        public bool IsSome { get; }
        public bool IsNone => !IsSome;

        public T Value => IsSome ? _some : throw new InvalidOperationException("Option is a NONE Type");

        private T _some;

        internal Option(bool isSome, T value)
        {
            if (isSome)
            {
                IsSome = true;
                if (value == null)
                    throw new ArgumentNullException($"Some({nameof(value)}) must not be null");
                _some = value;
            }
            else
            {
                IsSome = false;
                _some = default;
            }
        }

        public Monad<T> Unit()
            => this;

        public Monad<U> Pure<U>(U value) 
            => Option.From(value);

        public Monad<U> Bind<U>(Func<T, Monad<U>> bindFn)
            => IsSome
                ? bindFn(Value)
                : Option.None<U>();

        public bool Equals(Option<T> other)
            => IsSome == other.IsSome && _some.Equals(other._some) || IsNone == other.IsNone;

        public override bool Equals(object obj)
            => obj is Option<T> other ? Equals(other) : false;

        public static bool operator ==(Option<T> x, Monad<T> y)
            => x.Equals(y);

        public static bool operator !=(Option<T> x, Monad<T> y)
            => !x.Equals(y);

        public override int GetHashCode()
            => IsSome ? 397 * IsSome.GetHashCode() : 0;
    }
}
