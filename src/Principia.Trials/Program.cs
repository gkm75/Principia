﻿using System;
using System.Threading.Tasks;
using Principia.CSharp.FnX;
using Principia.CSharp.FnX.Functions;
using Principia.CSharp.FnX.Monads;
// using Principia.Monads;

namespace Principia.Trials
{
    class Program
    {
        // private static void OptionTypeTrial()
        // {
        //     var maybeX = Option.Some(668);
        //     var maybeY = Option.From("Hello World!");
        //     var maybeZ = Option.From<int?>(null);
        //
        //     Console.WriteLine(maybeX.Value);
        //     Console.WriteLine(maybeY.Value);
        //
        //     var m = maybeY.Unit();
        //     var n = maybeY.Bind(_ => Option.Some(9));
        // }
        //
        // private static void ResultTypeTrial()
        // {
        //     var resultValue = Result.Ok<int, string>(668);
        //
        //     if (resultValue.IsOk)
        //     {
        //         Console.WriteLine(resultValue.Value);
        //     }
        //
        //     var r2 = Result.Ok<Result<int, string>, string>(resultValue);
        //
        //     Console.WriteLine(r2.Value.Value);
        // }

        private static void IdentityMonadTrial()
        {
            var n = 4;
            var idN = Identity.From(n);

            var m = idN.Value;
            var idMap = idN.Map(x => x * 1);
            
            if (idN == idMap)
            {
                Console.WriteLine("Monads are Equal!");
            }
        }

        private static void OptionMonadTrial()
        {
            Option<int> n = Option.NONE;

            Option<int> fn(int c) => Option.Some(c);

            var c = fn(5);
            var (h, v) = c;

            var d =c.Map( h => h + 1) .MapNone( () => 2);
            
            var x = c.Map(async (int dd) => await Task.FromResult(dd)).Map( async j => (await j) + 1);
            c.WhenSome(s => { });
            var opt = Option.Some(9);
            var opt2 = opt.Bind(x => Option.Some(x.ToString()));

        }
        
        private static void ResultMonadTrial()
        {
            Result<int, bool> r = Result.Ok<int, bool>(1);

            var (h, _, _) = r;

            var x = Result.Ok(1);
            var y = ((int?)null).ToResult("bla");

            var xx = 1.Pipe(x => x + 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Principia!");
            // OptionTypeTrial();
            // ResultTypeTrial();


            IdentityMonadTrial();
            ResultMonadTrial();
        }
    }
}
