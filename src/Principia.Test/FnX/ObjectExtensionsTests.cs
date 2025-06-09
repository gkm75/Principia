using System;
using NSubstitute;
using NUnit.Framework;
using Principia.CSharp.FnX;
using Principia.CSharp.FnX.Monads;

namespace Principia.Test.FnX;

[TestFixture]
public class ObjectExtensionsTests
{
   [Test]
    public void Map_WithValidObjectAndFunc_TransformsObject()
    {
        // Arrange
        var person = new Person(1, "Alice");
        Func<Person, string> getName = p => p.Name;

        // Act
        var name = person.Map(getName);

        // Assert
        Assert.That(name, Is.EqualTo("Alice"));
    }

    [Test]
    public void Map_WithIntValue_PerformsCalculation()
    {
        // Arrange
        var number = 10;
        Func<int, int> doubler = n => n * 2;

        // Act
        var result = number.Map(doubler);

        // Assert
        Assert.That(result, Is.EqualTo(20));
    }

    [Test]
    public void DeepClone_WithReferenceType_CreatesDeepCopy()
    {
        // Arrange
        var original = new Person(123, "Bob");

        // Act
        var clone = original.DeepClone();

        // Assert
        Assert.That(clone, Is.Not.Null);
        Assert.That(clone, Is.Not.SameAs(original)); // Different instance
        Assert.That(clone.Id, Is.EqualTo(original.Id));     // Same values
        Assert.That(clone.Name, Is.EqualTo(original.Name));
    }

    [Test]
    public void DeepClone_WithNullObject_ReturnsDefault()
    {
        // Arrange
        Person? original = null;

        // Act
        var clone = original.DeepClone();

        // Assert
        Assert.That(clone, Is.Null);
    }

    [Test]
    public void Pipe_WhenCalled_ReturnsLazyFunction()
    {
        // Arrange
        var input = "test";
        var transformingFunc = Substitute.For<Func<object, int>>();
        
        // Act
        var pipedFunction = input.Pipe(transformingFunc);

        // Assert
        // The function should not have been called yet
        transformingFunc.DidNotReceive().Invoke(Arg.Any<object>());
        
        // Now, execute the lazy function
        pipedFunction();

        // The function should now have been called exactly once with the input
        transformingFunc.Received(1).Invoke(input);
    }
    
    [Test]
    public void Pipe_WhenInvoked_ReturnsCorrectTransformedValue()
    {
        // Arrange
        var input = "test string";
        Func<object, int> getLength = s => ((string)s).Length;
        
        // Act
        var pipedFunction = input.Pipe(getLength);
        var result = pipedFunction();

        // Assert
        Assert.That(result, Is.EqualTo(11));
    }

    [Test]
    public void ToOption_WithNonNullObject_ReturnsSome()
    {
        // Arrange
        var person = new Person(1, "Charlie");

        // Act
        var option = person.ToOption();

        // Assert
        Assert.That(option.IsSome, Is.True);
        Assert.That(option.Value, Is.EqualTo(person));
    }

    [Test]
    public void ToOption_WithNullObject_ReturnsNone()
    {
        // Arrange
        Person? person = null;
        
        // Act
        var option = person.ToOption();

        // Assert
        Assert.That(option.IsNone, Is.True);
    }

    [Test]
    public void ToResult_WithNonNullObjectAndOtherwiseValue_ReturnsOk()
    {
        // Arrange
        var input = "Success";
        var otherwise = "Failure";
        
        // Act
        var result = input.ToResult(otherwise);

        // Assert
        Assert.That(result.IsOk, Is.True);
        Assert.That(result.Value, Is.EqualTo(input));
    }
    
    [Test]
    public void ToResult_WithNullObjectAndOtherwiseValue_ReturnsFail()
    {
        // Arrange
        string? input = null;
        var otherwise = "Failure occurred";
        
        // Act
        var result = input.ToResult(otherwise);

        // Assert
        Assert.That(result.IsOk, Is.False);
        Assert.That(result.ValueFail, Is.EqualTo(otherwise));
    }
    
    [Test]
    public void ToResult_WithNonNullObjectAndFailureObject_ReturnsOk()
    {
        // Arrange
        var input = new Person(1, "David");
        var failure = new DefaultFailure();

        // Act
        var result = input.ToResult(failure);

        // Assert
        Assert.That(result.IsOk, Is.True);
        Assert.That(result.Value, Is.EqualTo(input));
    }

    [Test]
    public void ToResult_WithNullObjectAndFailureObject_ReturnsFail()
    {
        // Arrange
        Person? input = null;
        var failure = new DefaultFailure { ErrorMessage = "Object was null" };

        // Act
        var result = input.ToResult(failure);

        // Assert
        Assert.That(result.IsOk, Is.False);
        Assert.That(result.ValueFail, Is.SameAs(failure));
        Assert.That(result.ValueFail.ErrorMessage, Is.EqualTo("Object was null"));
    }

    [Test]
    public void ToResult_WithNonNullObjectAndLazyOtherwise_ReturnsOkAndDoesNotCallFunc()
    {
        // Arrange
        var input = "Success";
        var otherwiseFn = Substitute.For<Func<string>>();
        otherwiseFn.Invoke().Returns("Lazy Failure");

        // Act
        var result = input.ToResult(otherwiseFn);

        // Assert
        Assert.That(result.IsOk, Is.True);
        Assert.That(result.Value, Is.EqualTo(input));
        otherwiseFn.DidNotReceive().Invoke(); // Verify lazy evaluation
    }

    [Test]
    public void ToResult_WithNullObjectAndLazyOtherwise_ReturnsFailAndCallsFuncOnce()
    {
        // Arrange
        string? input = null;
        var otherwiseFn = Substitute.For<Func<string>>();
        otherwiseFn.Invoke().Returns("Lazy Failure");
        
        // Act
        var result = input.ToResult(otherwiseFn);

        // Assert
        Assert.That(result.IsOk, Is.False);
        Assert.That(result.ValueFail, Is.EqualTo("Lazy Failure"));
        otherwiseFn.Received(1).Invoke(); // Verify lazy evaluation
    }

    #region Helpers

    private record Person(int Id, string Name);
    
    private interface IFailure
    {
        string ErrorMessage { get; }
    }

    private class DefaultFailure : IFailure
    {
        public string ErrorMessage { get; init; } = "An error occurred.";
    }

    #endregion
}