using System;
using NSubstitute;
using NUnit.Framework;
using Principia.CSharp.FnX;
using Principia.CSharp.FnX.Functions;

namespace Principia.Test.FnX.Functions;

[TestFixture]
public class ActionExtensionsTests
{
    #region ToFunc Tests (Action -> Func<..., Unit>)

    [Test]
    public void ToFunc_WithParameterlessAction_CallsActionAndReturnsUnit()
    {
        // Arrange
        var wasCalled = false;
        Action action = () => { wasCalled = true; };

        // Act
        var func = action.ToFunc();
        var result = func();

        // Assert
        Assert.That(wasCalled, Is.True, "The original action should have been called.");
        Assert.That(result, Is.EqualTo(Unit.Value), "The function should return Unit.Value.");
    }

    [Test]
    public void ToFunc_WithOneParameterAction_CallsActionWithParameterAndReturnsUnit()
    {
        // Arrange
        var mockAction = Substitute.For<Action<string>>();
        var func = mockAction.ToFunc();
        const string testArgument = "hello world";

        // Act
        var result = func(testArgument);

        // Assert
        mockAction.Received(1).Invoke(testArgument);
        Assert.That(result, Is.EqualTo(Unit.Value));
    }

    [Test]
    public void ToFunc_WithMultipleParameterAction_CallsActionWithParametersAndReturnsUnit()
    {
        // Arrange
        // Using a three-parameter overload as a representative sample
        var mockAction = Substitute.For<Action<int, bool, double>>();
        var func = mockAction.ToFunc();
        const int arg1 = 42;
        const bool arg2 = true;
        const double arg3 = 3.14;

        // Act
        var result = func(arg1, arg2, arg3);

        // Assert
        mockAction.Received(1).Invoke(arg1, arg2, arg3);
        Assert.That(result, Is.EqualTo(Unit.Value));
    }

    #endregion

    #region ToAction Tests (Func<..., Unit> -> Action)

    [Test]
    public void ToAction_WithParameterlessFunc_CallsFunc()
    {
        // Arrange
        var mockFunc = Substitute.For<Func<Unit>>();
        var action = mockFunc.ToAction();

        // Act
        action();

        // Assert
        mockFunc.Received(1).Invoke();
    }

    [Test]
    public void ToAction_WithOneParameterFunc_CallsFuncWithParameter()
    {
        // Arrange
        var mockFunc = Substitute.For<Func<int, Unit>>();
        var action = mockFunc.ToAction();
        const int testArgument = 123;

        // Act
        action(testArgument);

        // Assert
        mockFunc.Received(1).Invoke(testArgument);
    }

    [Test]
    public void ToAction_WithMultipleParameterFunc_CallsFuncWithParameters()
    {
        // Arrange
        // Using a three-parameter overload as a representative sample
        var mockFunc = Substitute.For<Func<string, object, bool, Unit>>();
        var action = mockFunc.ToAction();
        
        var arg1 = "test";
        var arg2 = new object();
        var arg3 = false;

        // Act
        action(arg1, arg2, arg3);

        // Assert
        mockFunc.Received(1).Invoke(arg1, arg2, arg3);
    }

    #endregion
}