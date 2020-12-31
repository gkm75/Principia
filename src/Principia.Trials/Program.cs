using System;
using Principia.Monads;

namespace Principia.Trials
{
    class Program
    {
        private static void OptionTypeTrial()
        {
            var maybeX = Option.Some(668);
            var maybeY = Option.From("Hello World!");
            var maybeZ = Option.From<int?>(null);

            Console.WriteLine(maybeX.Value);
            Console.WriteLine(maybeY.Value);

            var m = maybeY.Unit();
            var n = maybeY.Bind(_ => Option.Some(9));
        }

        private static void ResultTypeTrial()
        {
            var resultValue = Result.Ok<int, string>(668);

            if (resultValue.IsOk)
            {
                Console.WriteLine(resultValue.Value);
            }

            var r2 = Result.Ok<Result<int, string>, string>(resultValue);

            Console.WriteLine(r2.Value.Value);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Pricipia!");
            OptionTypeTrial();
            ResultTypeTrial();
        }
    }
}
