using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace KeyVid.Core
{
    public class Video
    {
        public Guid id { get; set; }
        public Guid ownerGuid { get; set; }
        public string topic { get; set; }
        public List<Bitmap> coreScenes { get; set; }
        public List<String> keyNotes { get; set; }
        public List<String> statistics { get; set; }
        public int sceneCount { get; set; }
        public Bitmap scrapeImageHub(string topic, int place)
        {
            int debugPlace = place;
            string url = "https://unsplash.com/s/photos/" + topic.Replace(' ','-') + "?orientation=landscape";
            List<String> imageUrls = new List<String>();
            WebClient webClient = new WebClient();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "KeyVid");
            var htmlAsync = httpClient.GetStringAsync(url);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmlAsync.Result);
            var imageList = document.DocumentNode.Descendants("div").Where(r => r.GetAttributeValue("class", "").Contains("IEpfq"));
            foreach(var image in imageList)
            {
                string addedUrl = image.InnerHtml.Split('"')[7].Split(' ')[0];
                if (!(imageUrls.Contains(addedUrl)))
                {
                    imageUrls.Add(addedUrl);
                }
            }
            while(debugPlace >= imageUrls.Count())
            {
                debugPlace -= imageUrls.Count();
            }
            Stream imageStream = webClient.OpenRead(imageUrls[debugPlace]);
            Bitmap scrapedImage = new Bitmap(imageStream);
            DirectoryInfo newDirectory = Directory.CreateDirectory("wwwroot/images/" + topic);
            scrapedImage.Save("wwwroot/images/" + topic + "/" + topic + place + ".jpg", ImageFormat.Jpeg);
            return scrapedImage;
        }
        public Video(string topic, List<String> keyNotes, Guid ownerGuid)
        {
            this.id = Guid.NewGuid();
            this.ownerGuid = ownerGuid;
            this.statistics = scrapeStatistics(topic);
            this.topic = topic;
            this.keyNotes = keyNotes;
            this.coreScenes = new List<Bitmap>();
            this.sceneCount = this.keyNotes.Count + this.statistics.Count;
            for(int i = 0; i < this.sceneCount; i++)
            {
                coreScenes.Add(scrapeImageHub(this.topic, i));
            }
        }
        public List<String> scrapeStatistics(string topic)
        {
            List<String> statistics = new List<string>();
            //If I have time, do this
            return statistics;
        }
        public string createVideo()
        {
            string filePath = Guid.NewGuid().ToString() + ".mp4";
            //Use ffmpeg to create new videos
            return filePath;
        }
    }
}
