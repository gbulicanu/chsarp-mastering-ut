using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string setupDestinationFile;

        public bool DownloadInstaller(
            string customerName,
            string installerName)
        {
            try
            {

                new FileDownloader().DownloadFile(
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