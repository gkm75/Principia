using System;

namespace Principia.Monads
{
    public interface Result<TOk, TFail> : Monad<TOk>, IEquatable<Result<TOk, TFail>>
    {
        bool IsOk { get; }
        bool IsFail { get; }
        TFail FailValue { get; }
    }

    internal struct ResultOk<TOk, TFail> : Result<TOk, TFail>
    {
        public bool IsOk => true;

        public bool IsFail => false;

        public TOk Value { get; }

        public TFail FailValue => throw new InvalidOperationException($"ResultType is not a FAIL type");

        public bool Equals(Result<TOk, TFail> other)
            => this.IsOk == other.IsOk && this.Value.Equals(other.Value);

        internal ResultOk(TOk ok)
        {
            if (ok == null)
                throw new ArgumentNullException($"{nameof(ok)} must not be null");
            Value = ok;
        }

        public override int GetHashCode()
        {
            unchecked 
            { 
                return IsOk ? 397 * Value.GetHashCode() : Value.GetHashCode(); 
            }
        }

        public static bool operator ==(ResultOk<TOk, TFail> x, Monad<TOk> y)
            => x.Equals(y);

        public static bool operator !=(ResultOk<TOk, TFail> x, Monad<TOk> y)
            => !x.Equals(y);

        public override bool Equals(object obj)
            => (obj is ResultOk<TOk, TFail> resultOk) 
               ? resultOk.Value.Equals(Value)
               : false;

        public Monad<TOk> Unit()
            => this;

        public Monad<U> Pure<U>(U value)
            => Result.Ok<U, TFail>(value);

        public Monad<U> Bind<U>(Func<TOk, Monad<U>> bindFn)
        => IsOk
            ? bindFn(Value)
            : Result.Fail<U, TFail>(FailValue);
    }

    internal struct ResultFail<TOk, TFail> : Result<TOk, TFail>
    {
        public bool IsOk => false;

        public bool IsFail => true;

        public TOk Value => throw new InvalidOperationException($"ResultType is not an OK type");

        public TFail FailValue { get; }

        public bool Equals(Result<TOk, TFail> other)
            => this.IsFail == other.IsFail && this.FailValue.Equals(other.FailValue);

        internal ResultFail(TFail fail)
        {
            if (fail == null)
                throw new ArgumentNullException($"{nameof(fail)} must not be null");
            FailValue = fail;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return IsFail ? 397 * FailValue.GetHashCode() : FailValue.GetHashCode();
            }
        }

        public static bool operator ==(ResultFail<TOk, TFail> x, Result<TOk, TFail> y)
            => x.Equals(y);

        public static bool operator !=(ResultFail<TOk, TFail> x, Result<TOk, TFail> y)
            => !x.Equals(y);

        public override bool Equals(object obj)
            => (obj is ResultFail<TOk, TFail> resultFail)
               ? resultFail.FailValue.Equals(FailValue)
               : false;

        public Monad<TOk> Unit()
            => Result.Fail<TOk, TFail>(FailValue);

        public Monad<U> Pure<U>(U value)
            => Result.Ok<U, TFail>(value);

        public Monad<U> Bind<U>(Func<TOk, Monad<U>> bindFn)
            => Result.Fail<U, TFail>(FailValue);
    }
}

