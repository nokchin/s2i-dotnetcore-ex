using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;

namespace app.Controllers {
    public class HomeController : Controller {
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


        // CSGoh: added all my own stuff below .....
        private static Dictionary<string, string> _Cats = new Dictionary<string, string>();
        public static string[] Cats() {return _Cats.Keys.ToArray();}    //CSGoh:  this  Cats()  is actually a 'Method'.
        public static uint hit_count = 5;
        public static uint site_count = 5;
        public static string httpget;

        public IActionResult All() {
          hit_count++;
          return View();   //CSGoh: At first I omit/exclude this line, and I get compilation error (something like this):  HomeController.All not returning any value ....
        }

        [HttpGet("{abc}")]
        public IActionResult All(string abc) {
            _Cats["bill"] = "Meow!";
            _Cats["steve"] = "Hiss!";
            httpget = abc;   //CSGoh:  Special characters like:   !@$%^&*()+_=-~`"':;<>,.{}[]|   are all acceptable.  But special characters like:   #?/\   are not acceptable.
            site_count++;
          //if (abc != "x") {return View();}    //CSGoh: At first I write the  "return View()"  like this line, and I get compilation error (something like this):  HomeController.All not returning any value ....
            return View();
        }

        [HttpGet("add/{cat}")]
        public IActionResult All(string cat, string sound) {
            _Cats[cat] = sound;
            return View();
        }

    }
}
