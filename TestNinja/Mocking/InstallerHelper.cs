using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader fileDownloader;
        private string setupDestinationFile;

        public InstallerHelper(
            IFileDownloader fileDownloader,
            string setupDestinationFile = null)
        {
            this.fileDownloader = fileDownloader;
            this.setupDestinationFile = setupDestinationFile;
        }

        public bool DownloadInstaller(
            string customerName,
            string installerName)
        {
            try
            {
                this.fileDownloader.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    this.setupDestinationFile);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}