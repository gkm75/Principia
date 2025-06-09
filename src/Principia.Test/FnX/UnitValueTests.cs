using NUnit.Framework;
using Principia.CSharp.FnX;

namespace Principia.Test.FnX
{
    [TestFixture]
    public class UnitValueTests
    {
        #region Core Functionality

        [Test]
        public void Value_Always_ReturnsAUnitInstance()
        {
            // Act
            var unitValue = Unit.Value;

            // Assert
            Assert.That(unitValue, Is.InstanceOf<Unit>());
        }

        [Test]
        public void ToString_Always_ReturnsCorrectRepresentation()
        {
            // Arrange
            var unit = new Unit();
            const string expected = "()";

            // Act
            var result = unit.ToString();

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCode_Always_ReturnsZero()
        {
            // Arrange
            var unit1 = new Unit();
            var unit2 = Unit.Value;

            // Assert
            Assert.That(unit1.GetHashCode(), Is.EqualTo(0));
            Assert.That(unit2.GetHashCode(), Is.EqualTo(0));
        }

        #endregion

        #region IEquatable<Unit> and Equals(object)

        [Test]
        public void Equals_WithAnotherUnit_ReturnsTrue()
        {
            // Arrange
            var unit1 = new Unit();
            var unit2 = Unit.Value;

            // Act
            var result = unit1.Equals(unit2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_WithObjectAsUnit_ReturnsTrue()
        {
            // Arrange
            var unit1 = new Unit();
            object unit2 = new Unit();

            // Act
            var result = unit1.Equals(unit2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_WithNullObject_ReturnsFalse()
        {
            // Arrange
            var unit = new Unit();
            object? nullObject = null;

            // Act
            var result = unit.Equals(nullObject);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void Equals_WithDifferentTypeObject_ReturnsFalse()
        {
            // Arrange
            var unit = new Unit();
            var otherObject = new object();

            // Act
            var result = unit.Equals(otherObject);

            // Assert
            Assert.That(result, Is.False);
        }

        #endregion

        #region Operators

        [Test]
        public void OperatorEquals_TwoUnits_ReturnsTrue()
        {
            // Arrange
            var left = new Unit();
            var right = Unit.Value;

            // Act
            var result = left == right;

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void OperatorNotEquals_TwoUnits_ReturnsFalse()
        {
            // Arrange
            var left = new Unit();
            var right = Unit.Value;

            // Act
            var result = left != right;

            // Assert
            Assert.That(result, Is.False);
        }
        
        [Test]
        public void OperatorEquals_UnitAndObjectAsUnit_ReturnsTrue()
        {
            // Arrange
            var left = new Unit();
            object right = new Unit();

            // Act
            var result = left == right;

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void OperatorNotEquals_UnitAndObjectAsUnit_ReturnsFalse()
        {
            // Arrange
            var left = new Unit();
            object right = new Unit();

            // Act
            var result = left != right;

            // Assert
            Assert.That(result, Is.False);
        }
        
        [Test]
        public void OperatorEquals_UnitAndNullObject_ReturnsFalse()
        {
            // Arrange
            var left = new Unit();
            object? right = null;

            // Act
            var result = left == right;

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void OperatorNotEquals_UnitAndNullObject_ReturnsTrue()
        {
            // Arrange
            var left = new Unit();
            object? right = null;

            // Act
            var result = left != right;

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void OperatorEquals_UnitAndDifferentTypeObject_ReturnsFalse()
        {
            // Arrange
            var left = new Unit();
            object right = 123;

            // Act
            var result = left == right;

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void OperatorNotEquals_UnitAndDifferentTypeObject_ReturnsTrue()
        {
            // Arrange
            var left = new Unit();
            object right = "hello";

            // Act
            var result = left != right;

            // Assert
            Assert.That(result, Is.True);
        }

        #endregion
    }
}