using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //  .UseStartup<Startup>();    //CSGoh: replace this original line with the three lines below ...
                .UseStartup<Startup>()
                .UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30); })
                .Build();
    }
}


//  https://stackoverflow.com/questions/37474309/timeouts-with-long-running-asp-net-mvc-core-controller-httppost-method