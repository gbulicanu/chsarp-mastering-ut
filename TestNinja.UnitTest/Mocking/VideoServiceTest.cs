using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var videoService = new VideoService();

            var result = videoService.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}