﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace app
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            //CSGoh: this will display the full details of any run-time error.
            }
            else
            {
              //app.UseExceptionHandler("/Home/Error");     //Camilo advises me to comment this out.
              //app.UseHsts();                              //Camilo advises me to comment this out.
                app.UseDeveloperExceptionPage();            //CSGoh: Add this line here. This will display the full details of any run-time error.
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                  //template: "{controller=Home}/{action=Index}/{id?}");    //CSGoh: this is the original line. It will run  'Index.cshtml' .  -> HomeController.cs.org
                  //template: "{controller=Home}/{action=All}/{id?}");      //CSGoh: this is my line. It will run  'All.cshtml' .              -> HomeController.cs.org
                    template: "{controller=Home}/{action=Mine}/{id?}");     //CSGoh: this is my line. It will run  'Mine.cshtml' .             -> HomeController.cs
            });
        }
    }
}
