using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader fileReader;
        private readonly IVideoRepository videoRepository;

        public VideoService(
            IFileReader fileReader,
            IVideoRepository videoRepository)
        {
            this.fileReader = fileReader;
            this.videoRepository = videoRepository;
        }

        public string ReadVideoTitle()
        {
            var str = this.fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = this.videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return string.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}