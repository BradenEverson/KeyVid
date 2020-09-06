using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyVid.Core;
using KeyVid.Database;
using KeyVideo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyVideo
{
    public class galleryModel : PageModel
    {
        private readonly IVideoData videos;
        private readonly KeyVideoContext db;
        public KeyVidUser currentUser;
        public List<Video> userVideos;
        public galleryModel(KeyVideoContext db, IVideoData videos)
        {
            this.db = db;
            this.videos = videos;
        }
        public void OnGet()
        {
            currentUser = db.Users.FirstOrDefault(r => r.Email == User.Identity.Name);
            userVideos = videos.getAllByUser(Guid.Parse(currentUser.Id));
        }
    }
}