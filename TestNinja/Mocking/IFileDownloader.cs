namespace TestNinja
{
    public interface IFileDownloader
    {
        void DownloadFile(string customerName, string installerName, string setupDestinationFile);
    }
}