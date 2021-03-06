﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskingBoss.Areas.Identity.Data;
using TaskingBoss.Data;

[assembly: HostingStartup(typeof(TaskingBoss.Areas.Identity.IdentityHostingStartup))]
namespace TaskingBoss.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TaskingBossDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TaskingBossDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<TaskingBossDbContext>();
            });
        }
    }
}