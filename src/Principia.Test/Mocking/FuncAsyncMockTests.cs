using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Principia.Mocking;

namespace Principia.Test.Mocking
{
    [TestFixture]
    public class FuncAsyncMockTests
    {
        [Test]
        public void FuncAsyncMockTest()
        {
            var funcMock = FuncAsyncMock.Create<int>();
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
            var funcMock = FuncAsyncMock.Create<int>();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Once));
            funcMock.Object();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Never));
            funcMock.Object();
            Assert.Throws<VerifyInvokeException>(() => funcMock.VerifyInvoked(Times.Exactly(9)));
        }

        [Test]
        public void FuncAsyncMockWithParamTest()
        {
            var funcMock = FuncAsyncMock.Create<int, int>();
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
        public async Task FuncAsyncMockWithParamAndReturnValueTest()
        {
            var funcMock = FuncAsyncMock.Create<int, int>(4);
            funcMock.VerifyInvoked(Times.Never);
            var result = await funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.Once);
            result = await funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.Twice);
            result = await funcMock.Object(6);
            Assert.AreEqual(result, 4);
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public async Task FuncAsyncMockWithParamAndChainFnTest()
        {
            Task<int> ChainFnAsync(int p)
            {
                Assert.IsTrue(p == 6);
                return Task.FromResult(9);
            }

            var funcMock = FuncAsyncMock.Create<int, int>(ChainFnAsync);
            funcMock.VerifyInvoked(Times.Never);
            var result = await funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.Once);
            result = await funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.Twice);
            result = await funcMock.Object(6);
            Assert.AreEqual(result, 9);
            funcMock.VerifyInvoked(Times.AtLeast(1));
            funcMock.VerifyInvoked(Times.AtMost(3));
            funcMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void FuncAsyncMockWithExceptionTest()
        {
            var funcMock = FuncAsyncMock.Create<int>();
            funcMock.ThrowsException<InvalidOperationException>();
            funcMock.VerifyInvoked(Times.Never);
            Assert.Throws<InvalidOperationException>(() => funcMock.Object());
            funcMock.VerifyInvoked(Times.Once);
        }
    }
}
