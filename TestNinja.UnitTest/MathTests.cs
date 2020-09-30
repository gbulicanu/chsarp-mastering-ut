using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_WhenCalled_ShouldReturnTheSUmOfArguments()
        {
            // Arrange
            var math = new Math();

            // Act
            var result = math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }
    }
}