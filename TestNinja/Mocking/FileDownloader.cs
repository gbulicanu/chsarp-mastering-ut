using System.Net;

namespace TestNinja
{
    public class FileDownloader
    {

        public void DownloadFile(
            string customerName,
            string installerName,
            string setupDestinationFile)
        {
            using (var client = new WebClient())
            {

                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    setupDestinationFile);
            }
        }
    }
}