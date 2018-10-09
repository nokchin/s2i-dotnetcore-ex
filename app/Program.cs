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
                .UseStartup<Startup>();    //CSGoh: replace this original line with the three lines below ...
            //  .UseStartup<Startup>()
            //  .UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30); })
            //  .Build();
    }
}


//  https://stackoverflow.com/questions/37474309/timeouts-with-long-running-asp-net-mvc-core-controller-httppost-method
//  https://stackoverflow.com/questions/38698350/increase-upload-file-size-in-asp-net-core   [RequestSizeLimit(100_000_000)]  [DisableRequestSizeLimit]
//  http://www.dotnet-stuff.com/tutorials/aspnet-mvc/understanding-asp-net-mvc-filters-and-attributes     <---
//  https://www.itprotoday.com/web-development/attributes-controller
//  https://www.codeproject.com/Tips/1032266/MVC-Attributes

/*  https://msdn.microsoft.com/en-us/library/ms243175.aspx
Add the Timeout attribute to each test. The parameter is in milliseconds. For example:
[TestMethod(), Timeout(80)]
public void MyTestMethod()  
{  
// test code  
}

*/