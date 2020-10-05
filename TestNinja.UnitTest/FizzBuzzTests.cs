using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            const int input = 15;

            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            const int input = 3;

            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            const int input = 5;

            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnInput()
        {
            const int input = 1;

            var result = FizzBuzz.GetOutput(input);

            Assert.That(result, Is.EqualTo(input.ToString()));
        }
    }
}