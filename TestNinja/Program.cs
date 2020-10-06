using System;
using TestNinja.Mocking;

namespace TestNinja
{
    public class Program
    {
        public void Main(string[] args)
        {
            var videoService = new VideoService();
            var videoTitle = videoService.ReadVideoTitle();

            Console.WriteLine(videoTitle);
        }
    }
}