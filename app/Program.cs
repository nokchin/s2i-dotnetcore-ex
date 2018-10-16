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


// ** https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/introduction-to-signalr
          ->  https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-2.1&tabs=visual-studio
          ->  https://docs.microsoft.com/en-us/aspnet/core/signalr/index?view=aspnetcore-2.1
//  https://stackoverflow.com/questions/49816245/asp-net-core-2-1-server-timeout-while-debugging  <-- VERY GOOD!
    https://github.com/aspnet/Docs/issues/6885
//  https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit , https://docs.microsoft.com/en-us/dotnet/core/
//  https://stackoverflow.com/questions/34300204/why-doesnt-nunit-timeout-attribute-work
//  https://jeremylindsayni.wordpress.com/2016/05/28/how-to-set-a-maximum-time-to-allow-a-c-function-to-run-for/
//  https://stackoverflow.com/questions/37474309/timeouts-with-long-running-asp-net-mvc-core-controller-httppost-method
//  https://stackoverflow.com/questions/38698350/increase-upload-file-size-in-asp-net-core   [RequestSizeLimit(100_000_000)]  [DisableRequestSizeLimit]
//  http://www.dotnet-stuff.com/tutorials/aspnet-mvc/understanding-asp-net-mvc-filters-and-attributes     <---
//  https://www.itprotoday.com/web-development/attributes-controller
//  https://www.codeproject.com/Tips/1032266/MVC-Attributes
//  https://blogs.msdn.microsoft.com/aspnetue/2010/02/24/attributes-and-asp-net-mvc/

/*  https://msdn.microsoft.com/en-us/library/ms243175.aspx
Add the Timeout attribute to each test. The parameter is in milliseconds. For example:
[TestMethod(), Timeout(80)]
public void MyTestMethod()  
{  
// test code  
}

*/

//  https://wcfbiztalk.wordpress.com/2017/12/26/increase-timeout-for-asp-net-core-applications/   <- Good ! !
//  https://forums.asp.net/t/2135665.aspx?add+requestTimeout+in+web+config