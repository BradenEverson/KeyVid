using KeyVideo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVideo
{
    public class VideoHub : Hub
    {
        private UserManager<KeyVidUser> userManager;
        private KeyVideoContext db;
        public VideoHub(KeyVideoContext db, UserManager<KeyVidUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public async Task addToList(string item, Guid id)
        {
            KeyVidUser user = db.Users.FirstOrDefault(r => r.Id == id.ToString());
            user.infoList = user.infoList +  item + ",";
            Console.WriteLine(user.infoList);
            await userManager.UpdateAsync(user);
            await Clients.Caller.SendAsync("Added");
        }
        public async Task clean(Guid id)
        {
            KeyVidUser user = db.Users.FirstOrDefault(r => r.Id == id.ToString());
            user.infoList = "";
            await userManager.UpdateAsync(user);
        }
    }
}
