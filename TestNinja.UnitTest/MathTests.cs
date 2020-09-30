using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ShouldReturnTheSumOfArguments()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentsIsGreater_ReturnTheFirstArgument()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentsIsGreater_ReturnTheSecondArgument()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSame()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Max(1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}