using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTests
    {
        private Math math;

        [SetUp]
        public void SetUp()
        {
            this.math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ShouldReturnTheSumOfArguments()
        {
            // Act
            var result = this.math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Max_FirstArgumentsIsGreater_ReturnTheFirstArgument()
        {
            // Act
            var result = this.math.Max(2, 1);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentsIsGreater_ReturnTheSecondArgument()
        {
            // Act
            var result = this.math.Max(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSame()
        {
            // Act
            var result = this.math.Max(1, 1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}