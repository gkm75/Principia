namespace Principia.Monads
{
    public static class Option
    {
        public static Option<T> Some<T>(T value) => new Option<T>(true, value);

        public static Option<T> None<T>() => new Option<T>(false, default);

        public static Option<T> From<T>(T value) => value == null ? None<T>() : Some(value);
    }
}
