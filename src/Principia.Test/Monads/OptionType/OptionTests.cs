using System;
using NUnit.Framework;
using Principia.Monads;

namespace Principia.Test.Monads.OptionType
{
    [TestFixture]
    public class OptionTests
    {
        [Test]
        public void OptionSomeCreationTest()
        {
            var o1 = Option.Some(5);
            Assert.IsTrue(o1.IsSome);
            Assert.IsFalse(o1.IsNone);
            Assert.AreEqual(o1.Value, 5);

            var o2 = Option.From("Hello");
            Assert.IsTrue(o2.IsSome);
            Assert.IsFalse(o2.IsNone);
            Assert.AreEqual(o2.Value, "Hello");

            Assert.Throws<ArgumentNullException>(() => Option.Some<string>(null));
        }

        [Test]
        public void OptionNoneCreationTest()
        {
            var o1 = Option.None<int>();
            int n;
            Assert.IsTrue(o1.IsNone);
            Assert.IsFalse(o1.IsSome);
            Assert.AreEqual(o1, Option.None<int>());
            Assert.Throws<InvalidOperationException>(() => n = o1.Value);

            var o2 = Option.From<string>(null);
            Assert.IsTrue(o2.IsNone);
            Assert.IsFalse(o2.IsSome);
            Assert.AreEqual(o2, Option.None<string>());
        }

        [Test]
        public void OptionTryTest()
        {
            static string ExnFn() => throw new Exception("Generated Exception");

            var o1 = Option.Try(ExnFn);
            Assert.IsTrue(o1.IsNone);
            Assert.IsFalse(o1.IsSome);

            static string NoExnFn() => "Hello";

            var o2 = Option.Try(NoExnFn);
            Assert.IsTrue(o2.IsSome);
            Assert.IsFalse(o2.IsNone);
            Assert.AreEqual(o2.Value, "Hello");
        }
    }
}
