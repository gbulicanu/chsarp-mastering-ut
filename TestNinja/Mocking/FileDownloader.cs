using System.Net;

namespace TestNinja
{
    public class FileDownloader : IFileDownloader
    {

        public void DownloadFile(string url, string path)
        {
            using (var client = new WebClient())
            {

                client.DownloadFile(url, path);
            }
        }
    }
}