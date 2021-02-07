using System;
using NUnit.Framework;
using Principia.Monads;

namespace Principia.Test.Monads.Monad
{
    [TestFixture]
    public class MonadTests
    {
        [Test]
        public void MonadCreationTest()
        {
            var m1 = Option.Pure(7);
            Assert.AreEqual(m1.Value, 7);

            var m2 = Result.Pure<int, string>(7);
            Assert.AreEqual(m2.Value, 7);
        }

        [Test]
        public void MonadCreationFailTest()
        {
            Assert.Throws<ArgumentNullException>(() => Option.Pure<string>(null));
            Assert.Throws<ArgumentNullException>(() => Result.Pure<string, int>(null));
        }

        [Test]
        public void MonadMapTest()
        {
            static string MappingFn(int n) => n == 7 ? "Seven" : "Not Seven";

            var m1 = Option.Pure(7);
            Assert.AreEqual(m1.Value, 7);

            var m2 = m1.Map(MappingFn);
            Assert.AreEqual(m2.Value, "Seven");

            var m3 = Result.Pure(7);
            Assert.AreEqual(m3.Value, 7);

            var m4 = m3.Map(MappingFn);
            Assert.AreEqual(m4.Value, "Seven");
        }

        [Test]
        public void MonadMapFailTest()
        {
            var m1 = Option.Pure(7);

            Assert.Throws<NullReferenceException>(() => m1.Map<int, string>(null));
        }

        [Test]
        public void MonadBindTest()
        {
            static Monad<string> BindFn(int n) => n == 7 ? Option.Pure("Seven") : Option.Pure("Not Seven");

            var m1 = Option.Some(6).Bind(BindFn);
            Assert.AreEqual(m1.Value, "Not Seven");
        }

        [Test]
        public void MonadBindFailTest()
        {
            Assert.Throws<NullReferenceException>(() => Option.Some(6).Bind(null));
        }

        [Test]
        public void MonadJoinTest()
        {
            var m1 = Option.Pure(Option.Pure(9));
            var m2 = m1.Join();
            Assert.AreEqual(m2.Value, 9);
        }

        [Test]
        public void MonadApplicativeTest()
        {
            static string MappingFn(int n) => n == 7 ? "Seven" : "Not Seven";

            var ApplicativeFn = Option.Pure<Func<int, string>>(MappingFn);

            var m1 = Option.Pure(7);
            var m2 = m1.Applicative(ApplicativeFn);

            Assert.AreEqual(m2.Value, "Seven");
        }
    }
}
