using System;
using NUnit.Framework;
using Principia.Mocking;

namespace Principia.Test.Mocking
{
    [TestFixture]
    public class ActionMockTests
    {
        [Test]
        public void ActionMockTest()
        {
            var actionMock = ActionMock.Create();
            actionMock.VerifyInvoked(Times.Never);
            actionMock.Object();
            actionMock.VerifyInvoked(Times.Once);
            actionMock.Object();
            actionMock.VerifyInvoked(Times.Twice);
            actionMock.Object();
            actionMock.VerifyInvoked(Times.AtLeast(1));
            actionMock.VerifyInvoked(Times.AtMost(3));
            actionMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void ActionMockVerifyMismatchTest()
        {
            var actionMock = ActionMock.Create();
            Assert.Throws<VerifyInvokeException>(() => actionMock.VerifyInvoked(Times.Once));
            actionMock.Object();
            Assert.Throws<VerifyInvokeException>(() => actionMock.VerifyInvoked(Times.Never));
            actionMock.Object();
            Assert.Throws<VerifyInvokeException>(() => actionMock.VerifyInvoked(Times.Exactly(9)));
        }

        [Test]
        public void ActionMockWithParamTest()
        {
            var actionMock = ActionMock.Create<int>();
            actionMock.VerifyInvoked(Times.Never);
            actionMock.Object(1);
            actionMock.VerifyInvoked(Times.Once);
            actionMock.Object(2);
            actionMock.VerifyInvoked(Times.Twice);
            actionMock.Object(3);
            actionMock.VerifyInvoked(Times.AtLeast(1));
            actionMock.VerifyInvoked(Times.AtMost(3));
            actionMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void ActionMockWithParamAndChainFnTest()
        {
            void ChainFn(int p) => Assert.IsTrue(p == 6);

            var actionMock = ActionMock.Create<int>(ChainFn);
            actionMock.VerifyInvoked(Times.Never);
            actionMock.Object(6);
            actionMock.VerifyInvoked(Times.Once);
            actionMock.Object(6);
            actionMock.VerifyInvoked(Times.Twice);
            actionMock.Object(6);
            actionMock.VerifyInvoked(Times.AtLeast(1));
            actionMock.VerifyInvoked(Times.AtMost(3));
            actionMock.VerifyInvoked(Times.Between(1, 3));
        }

        [Test]
        public void ActionMockWithExceptionTest()
        {
            var actionMock = ActionMock.Create();
            actionMock.ThrowsException<InvalidOperationException>();
            actionMock.VerifyInvoked(Times.Never);
            Assert.Throws<InvalidOperationException>(() => actionMock.Object());
            actionMock.VerifyInvoked(Times.Once);
        }
    }
}
