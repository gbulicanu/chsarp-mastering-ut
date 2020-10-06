using Moq;

using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> fileReader;
        private VideoService videoService;


        [SetUp]
        public void SetUp()
        {
            this.fileReader = new Mock<IFileReader>();
            this.videoService = new VideoService(this.fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            fileReader.Setup(x => x.Read("video.txt")).Returns(string.Empty);

            var result = videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}