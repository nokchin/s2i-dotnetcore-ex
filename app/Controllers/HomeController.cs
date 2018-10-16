using System;
using System.Net;   //CSGoh: add in this line. If not, I get this compilation error:   the type or namespace name 'WebRequest' could not be found (are you missing a using directive or an assembly reference?) .
//using System.Net.HttpWebRequest;        //CSGoh: I get this compilation error here:    A 'using namespace' directive can only be applied to namespaces; 'HttpWebRequest' is a type not a namespace. Consider a 'using static' directive instead.
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;

namespace app.Controllers {
    public class HomeController : Controller {     //CSGoh: At first I add in 'WebRequest' here, and I get this compilation error:   Class 'HomeController' cannot have multiple base classes: 'Controller' and 'WebRequest' .
        public IActionResult Index() {
          //return View();  //CSGoh: I replace this original line with the new line below, to avoid run-time error if PageModel is used in  Index.cshtml.
            return View(new ErrorViewModel { Message = "Second Hello!" });  //A new expression requires (), [], or {} after type;  if not, got compilation error!
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }








        // CSGoh: added all my own stuff below ........

        public static uint loopcount = 0;

        [HttpGet("firstloop")]
        public void Mine() {
          while (true) {
            loopcount++;
            if (loopcount>11) {loopcount=0;}
          }
        }

        [HttpGet("checkalive")]
        public uint Mine(int aabbcc) {
          return loopcount;
        }

    }
}