using System;
using KeyVideo;
using KeyVideo.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(KeyVideo.Areas.Identity.IdentityHostingStartup))]
namespace KeyVideo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<KeyVideoContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("KeyVideoContextConnection")));

                services.AddDefaultIdentity<KeyVidUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<KeyVideoContext>();
            });
        }
    }
}