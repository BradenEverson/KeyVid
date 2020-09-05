using KeyVid.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyVid.Database
{
    public class InMemoryVideoData : IVideoData
    {
        List<Video> videos;
        public InMemoryVideoData()
        {
            videos = new List<Video>();
        }
        public Video add(Video video)
        {
            videos.Add(video);
            return video;
        }

        public Video delete(Video video)
        {
            videos.Remove(video);
            return video;
        }

        public List<Video> getAllByUser(Guid guid)
        {
            return videos.Where(r => r.ownerGuid == guid).ToList();
        }

        public Video getById(Guid id)
        {
            return videos.FirstOrDefault(r => r.id == id);
        }

        public Video update(Video video)
        {
            Video oldVideo = videos.FirstOrDefault(r => r.id == video.id);
            if(oldVideo != null)
            {
                oldVideo.keyNotes = video.keyNotes;
                oldVideo.sceneCount = video.sceneCount;
                oldVideo.statistics = video.statistics;
            }
            return oldVideo;
        }
    }
}
