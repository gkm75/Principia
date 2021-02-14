using System;
using NUnit.Framework;
using Principia.Mocking;

namespace Principia.Test.Mocking
{
    [TestFixture]
    public class FuncMockTests
    {
        [Test]
        public void FuncMockTest()
        {
            var funcMock = FuncMock.Create<int>();
            funcMock.VerifyInvoked(Times.Never);
            funcMock.Object();
            funcMock.VerifyInvoked(Times.Once);
            funcMock.Object();
            funcMock.VerifyInvoked(Times.Twice);
            funcMock.Object();
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void ActionMockVerifyMismatchTest()
        {
            var funcMock = FuncMock.Create<int>();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Once));
            funcMock.Object();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Never));
            funcMock.Object();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Exactly(9)));
        }

        [Test]
        public void FuncMockWithParamTest()
        {
            var funcMock = FuncMock.Create<int, int>();
            funcMock.VerifyInvoked(Times.Never);
            funcMock.Object(1);
            funcMock.VerifyInvoked(Times.Once);
            funcMock.Object(2);
            funcMock.VerifyInvoked(Times.Twice);
            funcMock.Object(3);
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void FuncMockWithParamAndReturnValueTest()
        {
            var funcMock = FuncMock.Create<int, int>(4);
            funcMock.VerifyInvoked(Times.Never);
            var result = funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.Once);
            result = funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.Twice);
            result = funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void FuncMockWithParamAndChainFnTest()
        {
            int ChainFn(int p)
            {
                Assert.IsTrue(p == 6);
                return 9;
            }

            var funcMock = FuncMock.Create<int, int>(ChainFn);
            funcMock.VerifyInvoked(Times.Never);
            var result = funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.Once);
            result = funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.Twice);
            result = funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void FuncMockWithExceptionTest()
        {
            var funcMock = FuncMock.Create<int>();
            funcMock.ThrowsException<InvalidOperationException>();
            funcMock.VerifyInvoked(Times.Never);
            Assert.Throws<InvalidOperationException>(() => funcMock.Object());
            funcMock.VerifyInvoked(Times.Once);
        }
    }
}
