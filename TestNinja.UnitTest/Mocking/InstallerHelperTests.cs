using Moq;

using NUnit.Framework;

using System.Net;

using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> fileDownloader;
        private InstallerHelper installerHelper;

        [SetUp]
        public void SetUp() 
        {
            this.fileDownloader = new Mock<IFileDownloader>();
            this.installerHelper = new InstallerHelper(
                fileDownloader.Object,
                "d");
        }

        [Test]
        public void DownloadInstaller_NetworkError_ReturnFalse() 
        {
            this.fileDownloader.Setup(x => x.DownloadFile("a", "b", "d"))
                .Throws<WebException>();

            var result = installerHelper.DownloadInstaller("a", "b");

            Assert.That(result, Is.False);
        }

        [Test]
        public void DownloadInstaller_SuccesfullDownload_ReturnTrue()
        {
            var result = installerHelper.DownloadInstaller("a", "b");

            Assert.That(result, Is.True);
        }
    }
}
