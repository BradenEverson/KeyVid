using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyVid.Core;
using KeyVid.Database;
using KeyVideo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyVideo
{
    public class CreateVideoModel : PageModel
    {
        [BindProperty]
        public string topic { get; set; }
        private readonly IVideoData videos;
        private KeyVideoContext db;
        public KeyVidUser currentUser;
        private UserManager<KeyVidUser> userManager;
        public CreateVideoModel(IVideoData videos, KeyVideoContext db, UserManager<KeyVidUser> userManager)
        {
            this.videos = videos;
            this.db = db;
            this.userManager = userManager;
        }
        public async void OnGet()
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            Console.WriteLine(currentUser.Id);
        }
        public void OnPost()
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            List<String> info = currentUser.infoList.Split(',').ToList();
            info.RemoveAt(info.Count - 1);
            Video video = new Video(topic, info, Guid.Parse(currentUser.Id));
            videos.add(video);
        }
    }
}