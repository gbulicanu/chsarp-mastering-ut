using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private readonly IFileDownloader fileDownloader;
        private string setupDestinationFile;

        public InstallerHelper(IFileDownloader fileDownloader)
        {
            this.fileDownloader = fileDownloader;
        }

        public bool DownloadInstaller(
            string customerName,
            string installerName)
        {
            try
            {

                this.fileDownloader.DownloadFile(
                    customerName,
                    installerName,
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