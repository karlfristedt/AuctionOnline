using System;
using AuctionOnline.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuctionOnline.Areas.Identity.IdentityHostingStartup))]
namespace AuctionOnline.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuctionOnlineContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuctionOnlineContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AuctionOnlineContext>();
            });
        }
    }
}