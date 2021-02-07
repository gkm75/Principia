using System;
using NUnit.Framework;
using Principia.Monads;

namespace Principia.Test.Monads.ResultType
{
    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void ResultOkCreationTest()
        {
            var r1 = Result.Ok<int, string>(5);
            Assert.IsTrue(r1.IsOk);
            Assert.IsFalse(r1.IsFail);
            Assert.AreEqual(r1.Value, 5);

            var r2 = Result.FromOr("Hello", "FailString");
            Assert.IsTrue(r2.IsOk);
            Assert.IsFalse(r1.IsFail);
            Assert.AreEqual(r2.Value, "Hello");

            Assert.Throws<ArgumentNullException>(() => Result.Ok<string, int>(null));
        }

        [Test]
        public void ResultFailCreationTest()
        {
            var r1 = Result.Fail<int, string>("FailString");
            Assert.IsTrue(r1.IsFail);
            Assert.IsFalse(r1.IsOk);
            Assert.AreEqual(r1.FailValue, "FailString");

            var r2 = Result.FromOr<string, string>(null, "FailString");
            Assert.IsTrue(r2.IsFail);
            Assert.IsFalse(r2.IsOk);
            Assert.AreEqual(r2.FailValue, "FailString");

            Assert.Throws<ArgumentNullException>(() => Result.Fail<int, string>(null));
        }

        [Test]
        public void ResultTryTest()
        {
            static string ExnFn() => throw new Exception("Generated Exception");

            var r1 = Result.Try(ExnFn, "FailString");
            Assert.IsTrue(r1.IsFail);
            Assert.IsFalse(r1.IsOk);
            Assert.AreEqual(r1.FailValue, "FailString");

            static string NoExnFn() => "Hello";

            var r2 = Result.Try(NoExnFn, "FailString");
            Assert.IsTrue(r2.IsOk);
            Assert.IsFalse(r2.IsFail);
            Assert.AreEqual(r2.Value, "Hello");
        }

    }
}
