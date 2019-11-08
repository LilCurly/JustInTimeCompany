using System;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.Entities;
using JustInTimeCompany_MuzikantovRoman.Infrastructure.Data.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JustInTimeCompany_MuzikantovRoman.Areas.Identity.IdentityHostingStartup))]
namespace JustInTimeCompany_MuzikantovRoman.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}