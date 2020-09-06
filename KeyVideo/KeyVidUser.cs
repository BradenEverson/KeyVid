using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyVideo
{
    public class KeyVidUser : IdentityUser
    {
        public Guid userGuid { get; }
        public string infoList { get; set; }
        public KeyVidUser()
        {
            this.userGuid = new Guid();
        }
    }
}
