using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldReturnEnclosedStringWithStrongElement()
        {
            var htmlFormater = new HtmlFormatter();

            var result = htmlFormater.FormatAsBold("abc");

            // Very specific test assertion
            Assert.That(result, Is.EqualTo("<strong>abc</strong>"));
        }
    }
}