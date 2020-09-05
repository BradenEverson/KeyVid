using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeyVid.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KeyVideo
{
    public class CreateVideoModel : PageModel
    {
        [BindProperty]
        public string information { get; set; }
        private readonly IVideoData videos;
        public CreateVideoModel(IVideoData videos)
        {
            this.videos = videos;
        }
        public void OnGet()
        {

        }
    }
}