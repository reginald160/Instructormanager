using System;
using Instructormanager.Areas.Identity.Data;
using Instructormanager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Instructormanager.Areas.Identity.IdentityHostingStartup))]
namespace Instructormanager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<InstructorDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("InstructorDBContextConnection")));

                services.AddDefaultIdentity<InstructormanagerUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<InstructorDBContext>();
            });
        }
    }
}