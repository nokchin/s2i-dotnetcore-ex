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
        public static uint run = 0;  // 0 - STOP  .   1 - running .

        [HttpGet("firstloop")]
        public void Mine() {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=1;
          while (run==1) {      // while (true) {
            loopcount++;
            if (loopcount>41) {loopcount=0;}
          }
          loopcount=0;  //this line is very important. Because exiting (getting out of) the loop above means that someone had pressed the 'STOP' button... so loopcount has to be reset to '0'.
        }

        [HttpGet("checkalive")]
        public uint Mine(int abc) {
          return loopcount;
        }

        [HttpGet("stop")]
        public void Mine(int abc, int def) {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=0;
        }

    }
}