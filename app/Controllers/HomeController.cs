using System;
using System.Net;   //CSGoh: add in this line. If not, I get this compilation error:   the type or namespace name 'WebRequest' could not be found (are you missing a using directive or an assembly reference?) .
//using System.Net.HttpWebRequest;        //CSGoh: I get this compilation error here:    A 'using namespace' directive can only be applied to namespaces; 'HttpWebRequest' is a type not a namespace. Consider a 'using static' directive instead.
//using System.Collections.Specialized;   //CSGoh: add in this line, so that I can use the  'WebClient()'  thing.
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app.Models;
using System.Timers;                      //CSGoh: add in this line, so that can use 'timer'.

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
/*   URL:  https://stackoverflow.com/questions/2044591/what-is-the-difference-between-array-getlength-and-array-length .
In C#, the  .GetLength() method takes an integer that specifies the dimension of the array that you're querying and returns its length.
The .Length property returns the total number of items in an array:
            int[,,] a = new int[10,11,12];
            Console.WriteLine(a.Length);           // 1320
            Console.WriteLine(a.GetLength(0));     // 10
            Console.WriteLine(a.GetLength(1));     // 11
            Console.WriteLine(a.GetLength(2));     // 12
And on one-dimensional array,  .Length will return the same value as .GetLength(0) .            */
        public static uint normalview = 1;
        private static System.Timers.Timer aTimer;
        public static string result = "";    //the correct nonce value that is wanted (used in the method that has the  [HttpGet("btc")]  attribute). This variable also serves as FIRST PLACE-HOLDER for main-hub's application program.
        public static string result1= "";    //SECOND PLACE-HOLDER for the main-hub's application program.

        public static uint loopcount = 0;
        public static uint run = 0;  // 0 - STOP  .   1 - running .
        public static string id = "";    // the 'id' is a 3-digit hex-string format.
        public static uint cpucount = 0;

        public static string hub="http://one-mainnhubb.d800.free-int.openshiftapps.com/";     //the ending/last  '/'  is a must.
      //public static string hub="http://tee-fif15tee.a3c1.starter-us-west-1.openshiftapps.com/";     //the ending/last  '/'  is a must.
        public static uint runstatus0 = 0;
        public static uint runstatus1 = 0;
        public static uint runstatus2 = 0;
        public static string[] cpu = {
//         "http://two-mainnhubb.d800.free-int.openshiftapps.com/",
//         "http://cuba-cubatest.d800.free-int.openshiftapps.com/",
//         "http://test-cubatest.d800.free-int.openshiftapps.com/",

           "http://kktan-pisang0.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://winny-pisang0.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://wha-whaxab1.193b.starter-ca-central-1.openshiftapps.com/",
           "http://xab-whaxab1.193b.starter-ca-central-1.openshiftapps.com/",
           "http://cs-fgush2.1d35.starter-us-east-1.openshiftapps.com/",
           "http://doe-fgush2.1d35.starter-us-east-1.openshiftapps.com/",
           "http://app-app3bee.7e14.starter-us-west-2.openshiftapps.com/",
           "http://bee-app3bee.7e14.starter-us-west-2.openshiftapps.com/",
           "http://east-epal4.193b.starter-ca-central-1.openshiftapps.com/",
           "http://fsgo-epal4.193b.starter-ca-central-1.openshiftapps.com/",
           "http://first-my5proj.193b.starter-ca-central-1.openshiftapps.com/",
           "http://second-my5proj.193b.starter-ca-central-1.openshiftapps.com/",
           "http://pea-pearoo6.7e14.starter-us-west-2.openshiftapps.com/",
           "http://roo-pearoo6.7e14.starter-us-west-2.openshiftapps.com/",
           "http://norm-re7ar.193b.starter-ca-central-1.openshiftapps.com/",
           "http://pick-re7ar.193b.starter-ca-central-1.openshiftapps.com/",
           "http://afe-patt8.7e14.starter-us-west-2.openshiftapps.com/",
           "http://boy-patt8.7e14.starter-us-west-2.openshiftapps.com/",
           "http://kit-semb9.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://tty-semb9.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://cru-sep10.1d35.starter-us-east-1.openshiftapps.com/",
           "http://doc-sep10.1d35.starter-us-east-1.openshiftapps.com/",
           "http://gul-e11e.1d35.starter-us-east-1.openshiftapps.com/",
           "http://zar-e11e.1d35.starter-us-east-1.openshiftapps.com/",
           "http://por-por12que.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://que-por12que.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://bad-badluc13.1d35.starter-us-east-1.openshiftapps.com/",
           "http://luc-badluc13.1d35.starter-us-east-1.openshiftapps.com/",
           "http://kis-kissin14.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://sin-kissin14.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://fif-fif15tee.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://tee-fif15tee.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://ssx-ssx16tek.1d35.starter-us-east-1.openshiftapps.com/",
           "http://tek-ssx16tek.1d35.starter-us-east-1.openshiftapps.com/",
           "http://chu-chulxa17.1d35.starter-us-east-1.openshiftapps.com/",
           "http://lxa-chulxa17.1d35.starter-us-east-1.openshiftapps.com/",
           "http://eig-eighte18.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://hte-eighte18.a3c1.starter-us-west-1.openshiftapps.com/",
           "http://nin-nin19teu.7e14.starter-us-west-2.openshiftapps.com/",
           "http://teu-nin19teu.7e14.starter-us-west-2.openshiftapps.com/",
           "http://twe-twe20uis.1d35.starter-us-east-1.openshiftapps.com/",
           "http://uis-twe20uis.1d35.starter-us-east-1.openshiftapps.com/"
        };


/* CSGoh: the code-block below can work. In fact, I use the code-block below as my first experiment to try/test out various fundamental/basic concepts ...
        [HttpGet("firstloop")]
        public void Mine() {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=1;
          while (run==1) {      // while (true) {
            loopcount++;
            if (loopcount>101) {loopcount=0;}
          }
          loopcount=0;  //this line is very important. Because exiting (getting out of) the loop above means that someone had pressed the 'STOP' button... so loopcount has to be reset to '0'.
        }           */
        public IActionResult Mine() {
          normalview=1;    return View();
        }

/* CSGoh: replace the original code-block below with a new code-block.
        [HttpGet("checkalive")]
        public uint Mine(int dummy) {
          return loopcount;
        }                     */
        //Usage:   ...Each_CPU_url.../checkalive    OR    ...HUB_url.../checkalive
        [HttpGet("checkalive")]
        public IActionResult Mine(int dummy) {
          //return loopcount;
          normalview=0;    return View();
        }

        //Usage:   ...Each_CPU_url.../stop
        [HttpGet("stop")]
        public void Mine(uint dummy) {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=0;
          using (var myclient = new WebClient()) {
            var responseString = myclient.DownloadString(hub + "runstatus/r"+ id);   //  "/r"  means Reset the 'runstatusX' bit to logic-0.
          }
        }

        //Usage1:   ...Each_CPU_url.../set/{hex 160-digit string  :->  the 154-digit serialized blocktemplate header, plus the hex 3-digit cpu/node-id, plus the hex 3-digit TOTAL cpu-count number}
        //Usage2:   ...Each_CPU_url.../set/00000000     -> this is the CANCEL command.
        [HttpGet("set/{nonce}")]
        public void Mine(string nonce) {
          if (!((nonce.Length>=160) && (run==1))) {
            if (result.Length>7) {
              if ((result!=nonce) && (!(result1.Length>7)) && (nonce.Length>7)) {result1=nonce;  if(nonce=="00000000"){run=0;}  }   //do NOT make 'result' & 'result1' to null-string ""  inside the  "if(nonce=="00000000"){...}"  statement.  Also do NOT make  (id="";)  here, because id is needed to communicate between cpu-node and the HUB.
            }
            else {
              if (nonce.Length>7) {result=nonce;  if(nonce=="00000000"){run=0;}  }   //do NOT make 'result' & 'result1' to null-string ""  inside the  "if(nonce=="00000000"){...}"  statement.  Also do NOT make  (id="";)  here, because id is needed to communicate between cpu-node and the HUB.
            }
          }
        }





        //CSGoh: I performed an experiment in which I choose a  nonce1  value that causes the Method below to run too long and produces the
        //       "504 Timeout Error".  After the "504 Timeout Error" appeared, I waited for some additional/extra time/moment to ensure this Method finishes
        //       running, and then checked the value of 'result' string variable, and found that 'result' really contains the desired nonce value!  So
        //       this shows that the Method below will continue running until it finishes, regardless of whether "504 Timeout Error" comes out or not.
        //Usage:   ...Each_CPU_url.../btc   <this will go into infinite loop, so user has to manually press the browser's STOP button> .
        [HttpGet("btc")]
        public void Mine(byte dummy) {

      //CSGoh: the line below can be used to replace the above TWO lines so that we can invoke/call this Method in the 'Mine.cshtml' file using Razor code like this:   @{HomeController.btc();}  . It is just like calling the  @{HomeController.Cats();}  Method in 'All.cshtml' .
//      public static string btc() {    //CSGoh: If I don't use 'static' here, I get this compilation error:   An object reference is required for the non-static field, method, or property.

      result = "";      // reset 'result' to null everytime this Method is called/entered. This is to clear/reset whatever previous nonce value that this string variable may hold/contain.
      result1= "";
while ((result!="00000000") && (result1!="00000000")) {     // if either 'result' or 'result1' is "00000000" , then it means the  CANCEL  condition.
uint extra_seconds = 0;
      //Below is the real block #504452  info/data.
        uint[] midstate = {0xc022dc5f,0x48274e98,0x6e353555,0x47bfc523,0x4811a092,0x207c9749,0x7657c67e,0x562a335c};
        string bits_expo = "17";   //I have run real cshtml experiment, and found that (unlike in Javascript) string in cshtml must be inside double-quote... cshtml string in single quote will NOT work (based on real experiment).
        string bits_coef = "0x7e578c";
        string merkleroot= "76dc896b48d682e80c6e96368649634e57742a1eeb171dd97c259ce0c6d6a757";
        string mintime = "d1b45d5a";
        string bits = "8c577e17";
      if ((result.Length>=160) && (run==0)) {
        run=1;
        // [Note]:  for real block #504452, the 'result' (exclude the cpu/node-id and TOTAL cpu count number) should take the value of:  c022dc5f48274e986e35355547bfc5234811a092207c97497657c67e562a335c170x7e578c76dc896b48d682e80c6e96368649634e57742a1eeb171dd97c259ce0c6d6a757d1b45d5a8c577e17
        midstate[0]=uint.Parse(result.Substring(0,8), System.Globalization.NumberStyles.HexNumber);
        midstate[1]=uint.Parse(result.Substring(8,8), System.Globalization.NumberStyles.HexNumber);
        midstate[2]=uint.Parse(result.Substring(16,8), System.Globalization.NumberStyles.HexNumber);
        midstate[3]=uint.Parse(result.Substring(24,8), System.Globalization.NumberStyles.HexNumber);
        midstate[4]=uint.Parse(result.Substring(32,8), System.Globalization.NumberStyles.HexNumber);
        midstate[5]=uint.Parse(result.Substring(40,8), System.Globalization.NumberStyles.HexNumber);
        midstate[6]=uint.Parse(result.Substring(48,8), System.Globalization.NumberStyles.HexNumber);
        midstate[7]=uint.Parse(result.Substring(56,8), System.Globalization.NumberStyles.HexNumber);
        bits_expo = result.Substring(64,2);
        bits_coef = result.Substring(66,8);
        merkleroot= result.Substring(74,64);
        mintime =  result.Substring(138,8);
        bits =     result.Substring(146,8);
        id = result.Substring(154,3);       // the 'id' is a 3-digit hex-string format.
        cpucount = uint.Parse(result.Substring(157,3), System.Globalization.NumberStyles.HexNumber);
        if (result.Length>160) {
          hub = "http://" + result.Substring(160,(result.Length)-160) + "/";
        }
        result="";   result1="";   //this line is very important.
        using (var myclient = new WebClient()) {
          var responseString = myclient.DownloadString(hub + "runstatus/s"+ id);   //  "/s"  means Set the 'runstatusX' bit to logic-1.
        }
      }
      else if ((result1.Length>=160) && (run==0)) {
        run=1;
        midstate[0]=uint.Parse(result1.Substring(0,8), System.Globalization.NumberStyles.HexNumber);
        midstate[1]=uint.Parse(result1.Substring(8,8), System.Globalization.NumberStyles.HexNumber);
        midstate[2]=uint.Parse(result1.Substring(16,8), System.Globalization.NumberStyles.HexNumber);
        midstate[3]=uint.Parse(result1.Substring(24,8), System.Globalization.NumberStyles.HexNumber);
        midstate[4]=uint.Parse(result1.Substring(32,8), System.Globalization.NumberStyles.HexNumber);
        midstate[5]=uint.Parse(result1.Substring(40,8), System.Globalization.NumberStyles.HexNumber);
        midstate[6]=uint.Parse(result1.Substring(48,8), System.Globalization.NumberStyles.HexNumber);
        midstate[7]=uint.Parse(result1.Substring(56,8), System.Globalization.NumberStyles.HexNumber);
        bits_expo = result1.Substring(64,2);
        bits_coef = result1.Substring(66,8);
        merkleroot= result1.Substring(74,64);
        mintime =  result1.Substring(138,8);
        bits =     result1.Substring(146,8);
        id = result1.Substring(154,3);       // the 'id' is a 3-digit hex-string format.
        cpucount = uint.Parse(result1.Substring(157,3), System.Globalization.NumberStyles.HexNumber);
        if (result1.Length>160) {
          hub = "http://" + result1.Substring(160,(result1.Length)-160) + "/";
        }
        result="";   result1="";   //this line is very important.
        using (var myclient = new WebClient()) {
          var responseString = myclient.DownloadString(hub + "runstatus/s"+ id);   //  "/s"  means Set the 'runstatusX' bit to logic-1.
        }
      }
      else if (run==1) {   //reaching here means something has gone wrong !
        run=0;   id="";
        if ((result=="00000000") || (result.Length>=160)) {result="";}
        if ((result1=="00000000") || (result1.Length>=160)) {result1="";}
      }

      uint blocktemplate=0;    // make 'blocktemplate' become a GLOBAL variable here.


/* I use real block #504452  info/data below to test/verify my whole algorithm/flow really works! The required nonce value is 6e383513 (in hex little-endian), which equals to 1849177363 (decimal).
midstate[0]=0xc022dc5f;
midstate[1]=0x48274e98;
midstate[2]=0x6e353555;
midstate[3]=0x47bfc523;
midstate[4]=0x4811a092;
midstate[5]=0x207c9749;
midstate[6]=0x7657c67e;
midstate[7]=0x562a335c;
bits_expo="17";
bits_coef="0x7e578c";
merkleroot="76dc896b48d682e80c6e96368649634e57742a1eeb171dd97c259ce0c6d6a757";
mintime="d1b45d5a";
bits="8c577e17";                       */
      // Paste below ....

      // Paste above ....




/*    nonce1 = prompt('Start-count nonce in HEX,  e.g.  fedcba98.  No \'0x\' in front.','');   //use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only.
      nonce2 = prompt('End-count nonce in HEX,  e.g.  0.  No \'0x\' in front.','');   //use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only.
      //'0' is a valid end-count value, because incrementing the last count value of 0xffffffff will wrap-around to become '0'. I have tested with real experiment by entering '0' or '1' as end-count value here, and everything works fine.
*/
      // nonce1 & nonce2  are hex STRINGs, without the '0x' in front ... just to follow the convention used in 'MineBxxxxxx1' Javascript code.
      // [Value pairs:  0x6e19b093 = 1847177363 (decimal,2-million less) .  0x6e36ae73 = 1849077363 (decimal).  0x6e3527d3 = 1848977363 (decimal).  0x6e321a93 = 1848777363 (decimal)].
      // [value pairs:  0x5f5e100  = 100 million (decimal) . 0xbebc200  = 200 million (decimal).  ].
      string nonce1 = "6e383500";   // [Value pairs:  0x6e28f2d3 = 1848177363 (decimal,1-million less).  0x6d811a13 = 18337177363 (decimal,12-million less).  0x6b5bc913 = 1801177363 (decimal,48-million less). ]
      string nonce2 = "6e383520";  //I have tested with real cshtml experiment on RedHat OpenShift platform with zero 'nonce2' value, and my cshtml program below can really terminate/exit the 'do-while' loop properly.

    //[Note]: my program generates hashes from 'nonce1' till 'nonce2'-1 , and please pay extra attention to the situation where the last nonce of '0xffffffff' wraps around to '0'.
    //Example1:  1000/13 = 76 with remainder=12 .  So: [1st_range: 0~77] , [2nd_range: 77~154] , [3rd_range: 154~231] , ... , [13th_range: 924~0]->assuming '999' wraps around to '0'.
    //Example2:  13/3 = 4 with remainder=1 .  So: [1st_range: 0~5] , [2nd_range: 5~9] , [3rd_range: 9~0]->assuming '12' wraps around to '0'.
    //Example3:  12/3 = 4 with remainder=0 .  So: [1st_range: 0~4] , [2nd_range: 4~8] , [3rd_range: 8~0]->assuming '11' wraps around to '0'.
    //However, later I decided NOT to follow the 'fair' scheme of 'Example1' & 'Example2' above, because it is too complicated to implement in codes.
      if (run==3) {
        blocktemplate=0xffffffff;   //by right the full-range here should be '0xffffffff+1' (=4,294,967,296 in decimal). However, an 'uint' variable can only take the maximum integer value of '0xffffffff' .
        blocktemplate=blocktemplate/cpucount;
        nonce1 = ((uint.Parse(id,System.Globalization.NumberStyles.HexNumber))*blocktemplate).ToString("x8");
        if (uint.Parse(id,System.Globalization.NumberStyles.HexNumber)==(cpucount-1)) {nonce2="0";}
        else {nonce2 = (((uint.Parse(id,System.Globalization.NumberStyles.HexNumber))+1)*blocktemplate).ToString("x8");}
      }


      uint[] h = {0x428a2f98,0x71374491,0xb5c0fbcf,0xe9b5dba5,0x3956c25b,0x59f111f1,0x923f82a4,0xab1c5ed5,
                  0xd807aa98,0x12835b01,0x243185be,0x550c7dc3,0x72be5d74,0x80deb1fe,0x9bdc06a7,0xc19bf174,
                  0xe49b69c1,0xefbe4786,0x0fc19dc6,0x240ca1cc,0x2de92c6f,0x4a7484aa,0x5cb0a9dc,0x76f988da,
                  0x983e5152,0xa831c66d,0xb00327c8,0xbf597fc7,0xc6e00bf3,0xd5a79147,0x06ca6351,0x14292967,
                  0x27b70a85,0x2e1b2138,0x4d2c6dfc,0x53380d13,0x650a7354,0x766a0abb,0x81c2c92e,0x92722c85,
                  0xa2bfe8a1,0xa81a664b,0xc24b8b70,0xc76c51a3,0xd192e819,0xd6990624,0xf40e3585,0x106aa070,
                  0x19a4c116,0x1e376c08,0x2748774c,0x34b0bcb5,0x391c0cb3,0x4ed8aa4a,0x5b9cca4f,0x682e6ff3,
                  0x748f82ee,0x78a5636f,0x84c87814,0x8cc70208,0x90befffa,0xa4506ceb,0xbef9a3f7,0xc67178f2};
/*    $h[0]=0x428a2f98; $h[1]=0x71374491; $h[2]=0xb5c0fbcf; $h[3]=0xe9b5dba5; $h[4]=0x3956c25b; $h[5]=0x59f111f1; $h[6]=0x923f82a4; $h[7]=0xab1c5ed5;
      $h[8]=0xd807aa98; $h[9]=0x12835b01; $h[10]=0x243185be; $h[11]=0x550c7dc3; $h[12]=0x72be5d74; $h[13]=0x80deb1fe; $h[14]=0x9bdc06a7; $h[15]=0xc19bf174;
      $h[16]=0xe49b69c1; $h[17]=0xefbe4786; $h[18]=0x0fc19dc6; $h[19]=0x240ca1cc; $h[20]=0x2de92c6f; $h[21]=0x4a7484aa; $h[22]=0x5cb0a9dc; $h[23]=0x76f988da;
      $h[24]=0x983e5152; $h[25]=0xa831c66d; $h[26]=0xb00327c8; $h[27]=0xbf597fc7; $h[28]=0xc6e00bf3; $h[29]=0xd5a79147; $h[30]=0x06ca6351; $h[31]=0x14292967;
      $h[32]=0x27b70a85; $h[33]=0x2e1b2138; $h[34]=0x4d2c6dfc; $h[35]=0x53380d13; $h[36]=0x650a7354; $h[37]=0x766a0abb; $h[38]=0x81c2c92e; $h[39]=0x92722c85;
      $h[40]=0xa2bfe8a1; $h[41]=0xa81a664b; $h[42]=0xc24b8b70; $h[43]=0xc76c51a3; $h[44]=0xd192e819; $h[45]=0xd6990624; $h[46]=0xf40e3585; $h[47]=0x106aa070;
      $h[48]=0x19a4c116; $h[49]=0x1e376c08; $h[50]=0x2748774c; $h[51]=0x34b0bcb5; $h[52]=0x391c0cb3; $h[53]=0x4ed8aa4a; $h[54]=0x5b9cca4f; $h[55]=0x682e6ff3;
      $h[56]=0x748f82ee; $h[57]=0x78a5636f; $h[58]=0x84c87814; $h[59]=0x8cc70208; $h[60]=0x90befffa; $h[61]=0xa4506ceb; $h[62]=0xbef9a3f7; $h[63]=0xc67178f2;    */

      uint[] m = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
      m[0] = uint.Parse(merkleroot.Substring(56,8), System.Globalization.NumberStyles.HexNumber);   // cannot use  int.Parse()  here, because m[] is a 'uint' array.
      m[1] = uint.Parse(mintime, System.Globalization.NumberStyles.HexNumber); 
      m[2] = uint.Parse(bits, System.Globalization.NumberStyles.HexNumber);
      m[3] = uint.Parse(nonce1, System.Globalization.NumberStyles.HexNumber);  // m[3] is nonce (use hex number here, just to follow the convention used in 'MineBxxxxxx1' Javascript code).
      m[4] = 0x80000000;
    //m[5]=0;   m[6]=0;   m[7]=0;   m[8]=0;   m[9]=0;     -> redundant, because these array elements have been assigned with '0' value during array initialization.
    //m[10]=0;  m[11]=0;  m[12]=0;  m[13]=0;  m[14]=0;    -> redundant, because these array elements have been assigned with '0' value during array initialization.
      m[15] = 0x00000280;
      // Now calculate  m[16] to m[63] .     [NOTE]: need to re-calculate m[18] to m[63] everytime the nonce m[3] changes -> m[16] and m[17] no need to re-calculate when nonce m[3] changes.
    //for (i=16; i<64; i++) { m[i]=((m[i-15]<<25|m[i-15]>>>7)^(m[i-15]<<14|m[i-15]>>>18)^m[i-15]>>>3)+m[i-7]+((m[i-2]<<15|m[i-2]>>>17)^(m[i-2]<<13|m[i-2]>>>19)^m[i-2]>>>10)+m[i-16] }    -> this line is the original Javascript code line.
      for (int i=16; i<18; i++) { m[i]= ((m[i-15]<<25| (m[i-15]>>7) )^(m[i-15]<<14| (m[i-15]>>18) )^ (m[i-15]>>3) )+m[i-7]+((m[i-2]<<15| (m[i-2]>>17) )^(m[i-2]<<13| (m[i-2]>>19) )^ (m[i-2]>>10) )+m[i-16];   }
    //redundant ->   for (int i=18; i<64; i++) { m[i]=0; }    // Important to initialize here so that m[0] till m[63] are defined as GLOBAL variable, before entering the loop below.

      uint[] mm = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    //redundant ->   for (int i=0; i<8; i++) { mm[i]=0; }    // Important to initialize here so that mm[0] till mm[7] are defined as GLOBAL variable, before entering the loop below.
      mm[8]=0x80000000;
    //redundant ->   mm[9]=0; mm[10]=0; mm[11]=0; mm[12]=0; mm[13]=0; mm[14]=0;
      mm[15]=0x00000100;
    //redundant ->   for (int i=16; i<64; i++) { mm[i]=0; }  // Important to initialize here so that mm[16] till mm[63] are defined as GLOBAL variable, before entering the loop below.



//  --------------------------------------------------------   Second-stage begins below ...   --------------------------------------------------------
/*    M0 (  0 ... 31  )  = merkleroot.substr(56,8)                          = W0                                reg_a ( 0  ... 31  )
      M1 ( 32 ... 63  )  = mintime                                          = W1                                reg_b ( 32 ... 63  )
      M2 ( 64 ... 95  )  = bits                                             = W2                                reg_c ( 64 ... 95  )
      M3 ( 96 ... 127 )  = nonce                                            = W3                                reg_d ( 96 ... 127 )
      M4 (128 ... 159 )  = 0x80000000 (fixed) ->  m[128] = 1                = W4                                reg_e ( 128 .. 159 )
      M5 (160 ... 191 )  = 0x00000000 (fixed)                               = W5                                reg_f ( 160 .. 191 )
      M6 (192 ... 223 )  = 0x00000000 (fixed)                               = W6                                reg_g ( 192 .. 223 )
      M7 (224 ... 255 )  = 0x00000000 (fixed)                               = W7                                reg_h ( 224 .. 255 )
      M8 (256 ... 287 )  = 0x00000000 (fixed)                               = W8
      M9 (288 ... 319 )  = 0x00000000 (fixed)                               = W9
     M10 (320 ... 351 )  = 0x00000000 (fixed)                               = W10
     M11 (352 ... 383 )  = 0x00000000 (fixed)                               = W11
     M12 (384 ... 415 )  = 0x00000000 (fixed)                               = W12
     M13 (416 ... 447 )  = 0x00000000 (fixed)                               = W13
     M14 (448 ... 479 )  = 0x00000000 (fixed)                               = W14
     M15 (480 ... 511 )  = 0x00000280 (fixed) ->  m[502] = m[504] = 1       = W15
*/


/*   ********************* The original (working) code-block below is replaced with a more optimized/efficient new code-block *********************
do {
      reg_a=midstate[0];   reg_b=midstate[1];   reg_c=midstate[2];   reg_d=midstate[3];
      reg_e=midstate[4];   reg_f=midstate[5];   reg_g=midstate[6];   reg_h=midstate[7];
for (i=0; i<64; i++) {
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^  computation for 1st (i=0) -> 64th (i=63) round, second-stage :   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      //   T1 = Ki  "mod 2^32 add"  reg_h   "mod 2^32 add"  Ch(e,f,g)  "mod 2^32 add"  SigmaBig1(e)  "mod 2^32 add"  m[i]
      //   T2 =  SigmaBig0(a)    "mod 2^32 add"     Maj(a,b,c)
      if (i>=18) { m[i]=((m[i-15]<<25|m[i-15]>>>7)^(m[i-15]<<14|m[i-15]>>>18)^m[i-15]>>>3)+m[i-7]+((m[i-2]<<15|m[i-2]>>>17)^(m[i-2]<<13|m[i-2]>>>19)^m[i-2]>>>10)+m[i-16] }  // need to re-calculate m[18] to m[63] everytime the nonce m[3] changes.
      blocktemplate=h[i]+reg_h+(reg_e&reg_f^~reg_e&reg_g)+((reg_e<<26|reg_e>>>6)^(reg_e<<21|reg_e>>>11)^(reg_e<<7|reg_e>>>25))+m[i];
      reg_h=reg_g;               // reg_h  <-  reg_g
      reg_g=reg_f;               // reg_g  <-  reg_f
      reg_f=reg_e;               // reg_f  <-  reg_e
      reg_e=reg_d+blocktemplate  // reg_e  <-  reg_d + T1
      blocktemplate=blocktemplate+((reg_a<<30|reg_a>>>2)^(reg_a<<19|reg_a>>>13)^(reg_a<<10|reg_a>>>22))+(reg_a&reg_b^reg_a&reg_c^reg_b&reg_c)  // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      reg_d=reg_c;               // reg_d  <-  reg_c
      reg_c=reg_b;               // reg_c  <-  reg_b
      reg_b=reg_a;               // reg_b  <-  reg_a
      reg_a=blocktemplate;       // reg_a  <-  (T1+T2)
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}
//   ------------------------------------------------------------   Second-stage ends here   ------------------------------------------------------------

************************ The original (working) code-block above is replaced with a more optimized/efficient new code-block ************************   */




// ********************* The more optimized/efficient new code-block below is to replace the original (working) code-block earlier *********************
      uint midvalue0=midstate[0];  uint midvalue1=midstate[1];  uint midvalue2=midstate[2];  uint midvalue3=midstate[3];
      uint midvalue4=midstate[4];  uint midvalue5=midstate[5];  uint midvalue6=midstate[6];  uint midvalue7=midstate[7];
for (int i=0; i<3; i++) {
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^  computation for 1st (i=0) -> 3rd (i=2) round, second-stage :   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      //   T1 = Ki  "mod 2^32 add"  reg_h   "mod 2^32 add"  Ch(e,f,g)  "mod 2^32 add"  SigmaBig1(e)  "mod 2^32 add"  m[i]
      //   T2 =  SigmaBig0(a)    "mod 2^32 add"     Maj(a,b,c)
      blocktemplate = h[i]+midvalue7+(midvalue4&midvalue5^~midvalue4&midvalue6)+((midvalue4<<26| (midvalue4>>6) )^(midvalue4<<21| (midvalue4>>11) )^(midvalue4<<7| (midvalue4>>25) ))+m[i];
      midvalue7=midvalue6;               // reg_h  <-  reg_g
      midvalue6=midvalue5;               // reg_g  <-  reg_f
      midvalue5=midvalue4;               // reg_f  <-  reg_e
      midvalue4=midvalue3+blocktemplate; // reg_e  <-  reg_d + T1
      blocktemplate= blocktemplate+((midvalue0<<30| (midvalue0>>2) )^(midvalue0<<19| (midvalue0>>13) )^(midvalue0<<10| (midvalue0>>22) ))+(midvalue0&midvalue1^midvalue0&midvalue2^midvalue1&midvalue2);       // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      midvalue3=midvalue2;               // reg_d  <-  reg_c
      midvalue2=midvalue1;               // reg_c  <-  reg_b
      midvalue1=midvalue0;               // reg_b  <-  reg_a
      midvalue0=blocktemplate;           // reg_a  <-  (T1+T2)
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}

while (run==1) {
do {
      uint reg_a=midvalue0;   uint reg_b=midvalue1;   uint reg_c=midvalue2;   uint reg_d=midvalue3;
      uint reg_e=midvalue4;   uint reg_f=midvalue5;   uint reg_g=midvalue6;   uint reg_h=midvalue7;
for (int i=3; i<64; i++) {
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^  computation for 4th (i=3) -> 64th (i=63) round, second-stage :   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      //   T1 = Ki  "mod 2^32 add"  reg_h   "mod 2^32 add"  Ch(e,f,g)  "mod 2^32 add"  SigmaBig1(e)  "mod 2^32 add"  m[i]
      //   T2 =  SigmaBig0(a)    "mod 2^32 add"     Maj(a,b,c)
      if (i>=18) { m[i]= ((m[i-15]<<25| (m[i-15]>>7) )^(m[i-15]<<14| (m[i-15]>>18) )^ (m[i-15]>>3) )+m[i-7]+((m[i-2]<<15| (m[i-2]>>17) )^(m[i-2]<<13| (m[i-2]>>19) )^ (m[i-2]>>10) )+m[i-16];   }     // need to re-calculate $m[18] to $m[63] everytime the nonce $m[3] changes.
      blocktemplate= h[i]+reg_h+(reg_e&reg_f^~reg_e&reg_g)+((reg_e<<26| (reg_e>>6) )^(reg_e<<21| (reg_e>>11) )^(reg_e<<7| (reg_e>>25) ))+m[i];
      reg_h=reg_g;               // reg_h  <-  reg_g
      reg_g=reg_f;               // reg_g  <-  reg_f
      reg_f=reg_e;               // reg_f  <-  reg_e
      reg_e=reg_d+blocktemplate;   // reg_e  <-  reg_d + T1
      blocktemplate= blocktemplate+((reg_a<<30| (reg_a>>2) )^(reg_a<<19| (reg_a>>13) )^(reg_a<<10| (reg_a>>22) ))+(reg_a&reg_b^reg_a&reg_c^reg_b&reg_c);   // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      reg_d=reg_c;               // reg_d  <-  reg_c
      reg_c=reg_b;               // reg_c  <-  reg_b
      reg_b=reg_a;               // reg_b  <-  reg_a
      reg_a=blocktemplate;       // reg_a  <-  (T1+T2)
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}
//   ------------------------------------------------------------   Second-stage ends here   ------------------------------------------------------------

// ********************* The more optimized/efficient new code-block above is to replace the original (working) code-block earlier *********************





      mm[0]=reg_a+midstate[0];   mm[1]=reg_b+midstate[1];   mm[2]=reg_c+midstate[2];   mm[3]=reg_d+midstate[3];
      mm[4]=reg_e+midstate[4];   mm[5]=reg_f+midstate[5];   mm[6]=reg_g+midstate[6];   mm[7]=reg_h+midstate[7];

/*    for (i=0; i<29; i+=4) {  document.write( ((mm[0] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[1] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[2] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[3] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[4] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[5] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[6] >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( ((mm[7] >>> (28-i)) & 15).toString(16) )  }
      document.write('<BR>');            */

      reg_a=0x6a09e667;   reg_b=0xbb67ae85;   reg_c=0x3c6ef372;   reg_d=0xa54ff53a;
      reg_e=0x510e527f;   reg_f=0x9b05688c;   reg_g=0x1f83d9ab;   reg_h=0x5be0cd19;

//  --------------------------------------------------------   Third-stage begins below ...   --------------------------------------------------------
for (int i=0; i<64; i++) {
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^  computation for 1st (i=0) -> 64th (i=63) round, third-stage :   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      //   T1 = Ki  "mod 2^32 add"  reg_h   "mod 2^32 add"  Ch(e,f,g)  "mod 2^32 add"  SigmaBig1(e)  "mod 2^32 add"  mm[i]
      //   T2 =  SigmaBig0(a)    "mod 2^32 add"     Maj(a,b,c)
      if (i>=16) { mm[i]= ((mm[i-15]<<25| (mm[i-15]>>7) )^(mm[i-15]<<14| (mm[i-15]>>18) )^ (mm[i-15]>>3) )+mm[i-7]+((mm[i-2]<<15| (mm[i-2]>>17) )^(mm[i-2]<<13| (mm[i-2]>>19) )^ (mm[i-2]>>10) )+mm[i-16]; }   // need to re-calculate $mm[16] to $mm[63] everytime $mm[0]-$mm[7] change.
      blocktemplate= h[i]+reg_h+(reg_e&reg_f^~reg_e&reg_g)+((reg_e<<26| (reg_e>>6) )^(reg_e<<21| (reg_e>>11) )^(reg_e<<7| (reg_e>>25) ))+mm[i];
      reg_h=reg_g;               // reg_h  <-  reg_g
      reg_g=reg_f;               // reg_g  <-  reg_f
      reg_f=reg_e;               // reg_f  <-  reg_e
      reg_e=reg_d+blocktemplate;  // reg_e  <-  reg_d + T1
      if (i==60) {   //(i==60)'s output reg_e will become (i==63)'s output reg_h.
        if ((reg_e+0x5be0cd19) != 0) {break;}  //At first I write:    if (reg_e+0x5be0cd19) {break;}      and C# compiler gives me error, saying cannot implicitly convert uint to boolean.
      //document.write('If this text is NOT displayed, it proves that the BREAK really makes the code/program exit the for() loop! <BR>');
      }
      if (i==61) {   //(i==61)'s output reg_e will become (i==63)'s output reg_g.
        if ((reg_e+0x1f83d9ab) != 0) {break;}  //Writing:      if (reg_e+0x1f83d9ab) {break;}       can work in Javascript, but NOT in C#.
      }
      if (i==62) {   //(i==62)'s output reg_e will become (i==63)'s output reg_f.
//      if (bits_expo=="17") {
/*  convert the following 3 original Javascript code lines to become equivalent PHP code lines below ...
          str=(reg_e+0x9b05688c)&0xffffffff;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
*/
/*  PHP:  $str=dechex($reg_e+0x9b05688c);   // remember: overflow could/possible happen here.  'str' now is a STRING type variable.
          if (substr($str,-2,2)!='00') {break;}  //[VERY IMPORTANT]: MUST have ending semicolon at   "break;"  . If not, RedHat OpenShift PHP interpreter will give error.
          if (hexdec(substr($str,-4,2).substr($str,-6,2).substr($str,-8,2)) < hexdec($bits_coef)) {     //success!
*/
          string str = (reg_e+0x9b05688c).ToString("x8");    // 'str' is now a hex (lower-case) string with 8-characters (with leading zeroes padded if necessary). For upper-case HEX string, use "X8" .
          if (str.Substring(6,2)!="00") {break;}
          if (uint.Parse(str.Substring(4,2)+str.Substring(2,2)+str.Substring(0,2),System.Globalization.NumberStyles.HexNumber) < uint.Parse(bits_coef.Substring(2,6),System.Globalization.NumberStyles.HexNumber)) {    //success!


//Javascript:    for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
//  PHP:         echo dechex($m[3]&0xffffffff);       echo "<BR>";
            result = m[3].ToString("x8");     // the correct/desired nonce value.
            result = result + "_" + extra_seconds.ToString("x4") + "HEX";
            str = hub + "set/" + result;
/* CSGoh: the code block below doesn't work on .NET Core 2.1 , I get this runtime error message:   ProtocolViolationException: Cannot send a content-body with this verb-type ->  System.Net.HttpWebRequest.InternalGetRequestStream() ,  System.Net.HttpWebRequest.GetRequestStream() .
            WebRequest myWebRequest = WebRequest.Create(str);    //WebRequest myWebRequest = WebRequest.Create("http://two-one.d800.free-int.openshiftapps.com/set/{nonce}");
            myWebRequest.Method = "GET";
          //myWebRequest.ContentLength = TranRequest.Length;   //Compilation error message:  The name 'TranRequest' does not exist in the current context.
            myWebRequest.ContentType = "application/x-www-form-urlencoded";  //to set content type.
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(myWebRequest.GetRequestStream());  //it will open a http connection with provided url.
            myWriter.Write("");  //send data.
            myWriter.Close();    //closed the myWriter object.        */

            using (var myclient = new WebClient()) {     // since WebClient implements IDisposable, so we can use 'using' statement here.
              var responseString = myclient.DownloadString(str);
            }
          //myclient.Close();   //redundant. The advantage of the "using" statement above (generally the preferred way of handling an open STREAM or CONNECTION) is that it ensures the stream/connection is closed and disposed of automatically/properly upon exiting the "using" statement.
          //If the "using" statement is NOT used, then we have to close the stream/connection manually, like:   myclient.Close();
            SetTimer();
            //run=1;   //Need to comment out this line here, because  "run" now is set to '1' on top.
            while (run==1) {}      // while (true) {}
            aTimer.Stop();
            aTimer.Dispose();

//          str = new Audio("buzzer_x.wav"); // buffers automatically when created
//          str.play();
//Javascript & PHP:       exit(0);     // exit entire PHP script normally.
            //break 2;    ->  "break 2"  is acceptable in PHP, but NOT in C#.
            if (nonce2=="0") {m[3]=0xffffffff;} else {m[3]=(uint.Parse(nonce2,System.Globalization.NumberStyles.HexNumber)-1);}
            break;
          }
          else {break;}  //[VERY IMPORTANT]: MUST have ending semicolon at   "break;"  . If not, RedHat OpenShift PHP interpreter will give error.
//      }
/*      else if (bits_expo=="16") {
          str=(reg_e+0x9b05688c)|0;
          if (str&0x0ffff) {break;}  //[VERY IMPORTANT]: MUST have ending semicolon at   "break;"  . If not, RedHat OpenShift PHP interpreter will give error.
          if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,6)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,6)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='16') condition/stage.
          }
          else {break;}  //[VERY IMPORTANT]: MUST have ending semicolon at   "break;"  . If not, RedHat OpenShift PHP interpreter will give error.
        }
        else if (bits_expo=="15") {
          str=(reg_e+0x9b05688c)|0;
          if (str&0x0ffffff) {break;}  //[VERY IMPORTANT]: MUST have ending semicolon at   "break;"  . If not, RedHat OpenShift PHP interpreter will give error.
          if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,4)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,4)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='15') condition/stage.
          }
          else {break}
        }
        else if ((('0x'+bits_expo)|0)<=0x14) {
          if ((reg_e+0x9b05688c)|0) {break}
        }         */
      }
/*    if (i==63) {
        if (bits_expo=="16") {
          str=(reg_e+0x510e527f)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16))|0) < (('0x'+bits_coef.substr(6,2))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=="15") {
          str=(reg_e+0x510e527f)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16))|0) < (('0x'+bits_coef.substr(4,4))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='14') {
          str=(reg_e+0x510e527f)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16))|0) < (bits_coef|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='13') {
          str=(reg_e+0x510e527f)|0;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='12') {
          str=(reg_e+0x510e527f)|0;
          if (str&0x0ffff) {break}
          if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,6)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,6)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='12') condition/stage of reg_d.
          }
          else {break}
        }
        else if (bits_expo=='11') {
          str=(reg_e+0x510e527f)|0;
          if (str&0x0ffffff) {break}
          if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,4)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,4)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='11') condition/stage of reg_d.
          }
          else {break}
        }
        else if ((('0x'+bits_expo)|0)<=0x10) {
          if ((reg_e+0x510e527f)|0) {break}
        }
      }                */
      blocktemplate= blocktemplate+((reg_a<<30| (reg_a>>2) )^(reg_a<<19| (reg_a>>13) )^(reg_a<<10| (reg_a>>22) ))+(reg_a&reg_b^reg_a&reg_c^reg_b&reg_c);   // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      reg_d=reg_c;               // reg_d  <-  reg_c
/*    if (i==63) {
        if (bits_expo=='12') {
          str=(reg_d+0xa54ff53a)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16))|0) < (('0x'+bits_coef.substr(6,2))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='11') {
          str=(reg_d+0xa54ff53a)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16))|0) < (('0x'+bits_coef.substr(4,4))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='10') {
          str=(reg_d+0xa54ff53a)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16))|0) < (bits_coef|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0f') {
          str=(reg_d+0xa54ff53a)|0;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0e') {
          str=(reg_d+0xa54ff53a)|0;
          if (str&0x0ffff) {break}
          if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,6)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,6)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='0e') condition/stage of reg_c.
          }
          else {break}
        }
        else if (bits_expo=='0d') {
          str=(reg_d+0xa54ff53a)|0;
          if (str&0x0ffffff) {break}
          if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,4)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,4)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='0d') condition/stage of reg_c.
          }
          else {break}
        }
        else if ((('0x'+bits_expo)|0)<=0x0c) {
          if ((reg_d+0xa54ff53a)|0) {break}
        }
      }          */
      reg_c=reg_b;               // reg_c  <-  reg_b
/*    if (i==63) {
        if (bits_expo=='0e') {
          str=(reg_c+0x3c6ef372)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16))|0) < (('0x'+bits_coef.substr(6,2))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0d') {
          str=(reg_c+0x3c6ef372)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16))|0) < (('0x'+bits_coef.substr(4,4))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0c') {
          str=(reg_c+0x3c6ef372)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16))|0) < (bits_coef|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0b') {
          str=(reg_c+0x3c6ef372)|0;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='0a') {
          str=(reg_c+0x3c6ef372)|0;
          if (str&0x0ffff) {break}
          if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,6)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,6)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='0a') condition/stage of reg_b.
          }
          else {break}
        }
        else if (bits_expo=='09') {
          str=(reg_c+0x3c6ef372)|0;
          if (str&0x0ffffff) {break}
          if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,4)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,4)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='09') condition/stage of reg_b.
          }
          else {break}
        }
        else if ((('0x'+bits_expo)|0)<=0x08) {
          if ((reg_c+0x3c6ef372)|0) {break}
        }
      }             */
      reg_b=reg_a;               // reg_b  <-  reg_a
/*    if (i==63) {
        if (bits_expo=='0a') {
          str=(reg_b+0xbb67ae85)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16))|0) < (('0x'+bits_coef.substr(6,2))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='09') {
          str=(reg_b+0xbb67ae85)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16))|0) < (('0x'+bits_coef.substr(4,4))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='08') {
          str=(reg_b+0xbb67ae85)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16))|0) < (bits_coef|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='07') {
          str=(reg_b+0xbb67ae85)|0;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='06') {
          str=(reg_b+0xbb67ae85)|0;
          if (str&0x0ffff) {break}
          if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,6)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,6)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='06') condition/stage of reg_a.
          }
          else {break}
        }
        else if (bits_expo=='05') {
          str=(reg_b+0xbb67ae85)|0;
          if (str&0x0ffffff) {break}
          if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef.substr(0,4)|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else if ((('0x'+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) == (bits_coef.substr(0,4)|0)) {
            //equality happens ... do nothing here because success or failure is undetermined ... need to check/test further at:  (i==63) plus (bits_expo=='05') condition/stage of reg_a.
          }
          else {break}
        }
        else if ((('0x'+bits_expo)|0)<=0x04) {
          if ((reg_b+0xbb67ae85)|0) {break}
        }
      }          */
      reg_a=blocktemplate;       // reg_a  <-  (T1+T2)
/*    if (i==63) {
        if (bits_expo=='06') {
          str=(reg_a+0x6a09e667)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16))|0) < (('0x'+bits_coef.substr(6,2))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='05') {
          str=(reg_a+0x6a09e667)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16))|0) < (('0x'+bits_coef.substr(4,4))|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='04') {
          str=(reg_a+0x6a09e667)|0;
          if ((('0x'+((str>>>4)&15).toString(16)+((str>>>0)&15).toString(16)+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16))|0) < (bits_coef|0)) {   //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
        else if (bits_expo=='03') {
          str=(reg_a+0x6a09e667)|0;
          if (str&0x0ff) {break}
          if ((('0x'+((str>>>12)&15).toString(16)+((str>>>8)&15).toString(16)+((str>>>20)&15).toString(16)+((str>>>16)&15).toString(16)+((str>>>28)&15).toString(16)+((str>>>24)&15).toString(16))|0) < (bits_coef|0)) {    //success!
            for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
            str = new Audio("buzzer_x.wav"); // buffers automatically when created
            str.play();
            exit(0)
          }
          else {break}
        }
      }            */
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}

//   ------------------------------------------------------------   Third-stage ends here   ------------------------------------------------------------

/* IMPORTANT NOTE:  the display result below won't be correct if the  BREAK  above happens, which takes place almost everytime!
      for (i=0; i<29; i+=4) {  document.write( (((reg_a+0x6a09e667) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_b+0xbb67ae85) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_c+0x3c6ef372) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_d+0xa54ff53a) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_e+0x510e527f) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_f+0x9b05688c) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_g+0x1f83d9ab) >>> (28-i)) & 15).toString(16) )  }
      for (i=0; i<29; i+=4) {  document.write( (((reg_h+0x5be0cd19) >>> (28-i)) & 15).toString(16) )  }
      document.write('<BR>');           */

      m[3]=m[3]+1;    //increment the m[3] nonce.
    //if (m[3]==(tmp*400000)) { document.write(' '+(tmp-1)); tmp++;     if (!(tmp%20)) {document.write('<BR>')}  }    //good for monitoring purpose. Comment out to save execution time.
//} while (m[3]!=0xffffffff)   //originally I use  (m[3]!=0) , thinking the nonce will roll-over from 0xffffffff to 0x00 when increment. But later I ran a real-life experiment, and found that if I use  (m[3]!=0) , the loop will never exit. Using  (m[3]!=0xffffffff)  will exit the loop, but the last nonce '0xffffffff' will not get tested/checked.
//} while (m[3]|0)    //the loop will exit using this line.    I have tried before using  "while (m[3])"  and the loop does NOT exit (maybe due to the carry-over bit?).
//} while (m[3]!=0x3)     //for experiment purpose (better use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only).
//} while (m[3]!=1949177363)   // =0x742e1613.  For experiment purpose (better use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only).
  } while (  (m[3] != uint.Parse(nonce2,System.Globalization.NumberStyles.HexNumber)) && (run==1)   );   //better use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only.
                               //[VERY IMPORTANT]: MUST have ending semicolon at the   "do {} while (...);"   statement. If not, RedHat OpenShift PHP interpreter will give error.

//    blocktemplate = new Audio("buzzer_x.wav"); // buffers automatically when created
//    blocktemplate.play();
    //return result;      // ------ no need  "return"  here, IF this method is defined as  "VOID"  type, and there won't be any compilation error. ------ //


      if (run==1) {
      extra_seconds++;
      for (int i=0; i<64; i++) {m[i]=0;}
      m[0] = uint.Parse(merkleroot.Substring(56,8), System.Globalization.NumberStyles.HexNumber);   // cannot use  int.Parse()  here, because m[] is a 'uint' array.
      string str = (uint.Parse((mintime.Substring(6,2)+mintime.Substring(4,2)+mintime.Substring(2,2)+mintime.Substring(0,2)),System.Globalization.NumberStyles.HexNumber)+extra_seconds).ToString("x8");   // 'str' here is in big-endian hex-string format.
      m[1] = uint.Parse((str.Substring(6,2)+str.Substring(4,2)+str.Substring(2,2)+str.Substring(0,2)), System.Globalization.NumberStyles.HexNumber);    //convert 'str' to little-endian here.
      m[2] = uint.Parse(bits, System.Globalization.NumberStyles.HexNumber);
      m[3] = uint.Parse(nonce1, System.Globalization.NumberStyles.HexNumber);  // m[3] is nonce (use hex number here, just to follow the convention used in 'MineBxxxxxx1' Javascript code).
      m[4] = 0x80000000;
    //m[5]=0;   m[6]=0;   m[7]=0;   m[8]=0;   m[9]=0;     -> redundant, because these array elements have been assigned with '0' value above.
    //m[10]=0;  m[11]=0;  m[12]=0;  m[13]=0;  m[14]=0;    -> redundant, because these array elements have been assigned with '0' value above.
      m[15] = 0x00000280;
      // Now calculate  m[16] to m[63] .     [NOTE]: need to re-calculate m[18] to m[63] everytime the nonce m[3] changes -> m[16] and m[17] no need to re-calculate when nonce m[3] changes.
    //for (i=16; i<64; i++) { m[i]=((m[i-15]<<25|m[i-15]>>>7)^(m[i-15]<<14|m[i-15]>>>18)^m[i-15]>>>3)+m[i-7]+((m[i-2]<<15|m[i-2]>>>17)^(m[i-2]<<13|m[i-2]>>>19)^m[i-2]>>>10)+m[i-16] }    -> this line is the original Javascript code line.
      for (int i=16; i<18; i++) { m[i]= ((m[i-15]<<25| (m[i-15]>>7) )^(m[i-15]<<14| (m[i-15]>>18) )^ (m[i-15]>>3) )+m[i-7]+((m[i-2]<<15| (m[i-2]>>17) )^(m[i-2]<<13| (m[i-2]>>19) )^ (m[i-2]>>10) )+m[i-16];   }
    //redundant ->   for (int i=18; i<64; i++) { m[i]=0; }    // Important to initialize here so that m[0] till m[63] are defined as GLOBAL variable, before entering the loop below.

      for (int i=0; i<64; i++) {mm[i]=0;}
    //redundant ->   for (int i=0; i<8; i++) { mm[i]=0; }    // Important to initialize here so that mm[0] till mm[7] are defined as GLOBAL variable, before entering the loop below.
      mm[8]=0x80000000;
    //redundant ->   mm[9]=0; mm[10]=0; mm[11]=0; mm[12]=0; mm[13]=0; mm[14]=0;
      mm[15]=0x00000100;
    //redundant ->   for (int i=16; i<64; i++) { mm[i]=0; }  // Important to initialize here so that mm[16] till mm[63] are defined as GLOBAL variable, before entering the loop below.

      midvalue0=midstate[0];  midvalue1=midstate[1];  midvalue2=midstate[2];  midvalue3=midstate[3];
      midvalue4=midstate[4];  midvalue5=midstate[5];  midvalue6=midstate[6];  midvalue7=midstate[7];
for (int i=0; i<3; i++) {
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^  computation for 1st (i=0) -> 3rd (i=2) round, second-stage :   ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
      //   T1 = Ki  "mod 2^32 add"  reg_h   "mod 2^32 add"  Ch(e,f,g)  "mod 2^32 add"  SigmaBig1(e)  "mod 2^32 add"  m[i]
      //   T2 =  SigmaBig0(a)    "mod 2^32 add"     Maj(a,b,c)
      blocktemplate = h[i]+midvalue7+(midvalue4&midvalue5^~midvalue4&midvalue6)+((midvalue4<<26| (midvalue4>>6) )^(midvalue4<<21| (midvalue4>>11) )^(midvalue4<<7| (midvalue4>>25) ))+m[i];
      midvalue7=midvalue6;               // reg_h  <-  reg_g
      midvalue6=midvalue5;               // reg_g  <-  reg_f
      midvalue5=midvalue4;               // reg_f  <-  reg_e
      midvalue4=midvalue3+blocktemplate; // reg_e  <-  reg_d + T1
      blocktemplate= blocktemplate+((midvalue0<<30| (midvalue0>>2) )^(midvalue0<<19| (midvalue0>>13) )^(midvalue0<<10| (midvalue0>>22) ))+(midvalue0&midvalue1^midvalue0&midvalue2^midvalue1&midvalue2);       // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      midvalue3=midvalue2;               // reg_d  <-  reg_c
      midvalue2=midvalue1;               // reg_c  <-  reg_b
      midvalue1=midvalue0;               // reg_b  <-  reg_a
      midvalue0=blocktemplate;           // reg_a  <-  (T1+T2)
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}
      }   //the closing bracket for  "if(run==1){...}"  loop.

}         //the closing bracket for the  "while(run==1){...}"  loop.


}         //the closing bracket for the  CANCEL  condition.
      run=0;
      //id="";      //comment this out, because id is needed to communicate between the cpu-node and HUB.
      if (result=="00000000") {result="";}       // this line is very important.
      if (result1=="00000000") {result1="";}     // this line is very important.
      using (var myclient = new WebClient()) {
         var responseString = myclient.DownloadString(hub + "runstatus/r"+ id);   //  "/r"  means Reset the 'runstatusX' bit to logic-0.
      }
        }


        private static void SetTimer() {
          aTimer = new System.Timers.Timer(7000);   // Create a timer with a seven second (7000ms) interval.
          aTimer.Elapsed += OnTimedEvent;           // Hook up the Elapsed event for the timer.
          aTimer.AutoReset = true;
          aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e) {
          //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
/* CSGoh: In order to prove that the timer really triggers in every fixed interval, I use the code-block below to carry out a real-life experiment by
          setting the 'result' variable at the HUB to the correct nonce value, and "0"  ALTERNATELY.  I then use  "...HUB_URL.../checkalive"  to check/
          verify that the 'result' variable at the HUB really get changed/toggled between the correct nonce value and "0"  ALTERNATELY. This shows that
          the timer really triggers in every fix interval.
          loopcount++;
          if (loopcount>=2) {
            loopcount=0;
            using (var myclient = new WebClient()) {
              var responseString = myclient.DownloadString(hub + "set/"+result);
            }
          }
          else {    // (loopcount==1) .
            using (var myclient = new WebClient()) {
              var responseString = myclient.DownloadString(hub + "set/"+"0");
            }
          }
*/
          using (var myclient = new WebClient()) {
              var responseString = myclient.DownloadString(hub + "set/"+result);
          }
        }


        [HttpGet("runstatus/{str}")]
        public void Mine(uint dummy, string str) {
          string action = str.Substring(0,1);
          str = str.Substring(1,(str.Length)-1);
          switch(str) {
            case "000":
              if (action=="s") {runstatus0=runstatus0|0x80000000;} else
              if (action=="r") {runstatus0=runstatus0&0x7fffffff;}
              break;
            case "001":
              if (action=="s") {runstatus0=runstatus0|0x40000000;} else
              if (action=="r") {runstatus0=runstatus0&0xbfffffff;}
              break;
            case "002":
              if (action=="s") {runstatus0=runstatus0|0x20000000;} else
              if (action=="r") {runstatus0=runstatus0&0xdfffffff;}
              break;
            case "003":
              if (action=="s") {runstatus0=runstatus0|0x10000000;} else
              if (action=="r") {runstatus0=runstatus0&0xefffffff;}
              break;
            case "004":
              if (action=="s") {runstatus0=runstatus0|0x08000000;} else
              if (action=="r") {runstatus0=runstatus0&0xf7ffffff;}
              break;
            case "005":
              if (action=="s") {runstatus0=runstatus0|0x04000000;} else
              if (action=="r") {runstatus0=runstatus0&0xfbffffff;}
              break;
            case "006":
              if (action=="s") {runstatus0=runstatus0|0x02000000;} else
              if (action=="r") {runstatus0=runstatus0&0xfdffffff;}
              break;
            case "007":
              if (action=="s") {runstatus0=runstatus0|0x01000000;} else
              if (action=="r") {runstatus0=runstatus0&0xfeffffff;}
              break;
            case "008":
              if (action=="s") {runstatus0=runstatus0|0x00800000;} else
              if (action=="r") {runstatus0=runstatus0&0xff7fffff;}
              break;
            case "009":
              if (action=="s") {runstatus0=runstatus0|0x00400000;} else
              if (action=="r") {runstatus0=runstatus0&0xffbfffff;}
              break;
            case "00a":
              if (action=="s") {runstatus0=runstatus0|0x00200000;} else
              if (action=="r") {runstatus0=runstatus0&0xffdfffff;}
              break;
            case "00b":
              if (action=="s") {runstatus0=runstatus0|0x00100000;} else
              if (action=="r") {runstatus0=runstatus0&0xffefffff;}
              break;
            case "00c":
              if (action=="s") {runstatus0=runstatus0|0x00080000;} else
              if (action=="r") {runstatus0=runstatus0&0xfff7ffff;}
              break;
            case "00d":
              if (action=="s") {runstatus0=runstatus0|0x00040000;} else
              if (action=="r") {runstatus0=runstatus0&0xfffbffff;}
              break;
            case "00e":
              if (action=="s") {runstatus0=runstatus0|0x00020000;} else
              if (action=="r") {runstatus0=runstatus0&0xfffdffff;}
              break;
            case "00f":
              if (action=="s") {runstatus0=runstatus0|0x00010000;} else
              if (action=="r") {runstatus0=runstatus0&0xfffeffff;}
              break;
            case "010":
              if (action=="s") {runstatus0=runstatus0|0x00008000;} else
              if (action=="r") {runstatus0=runstatus0&0xffff7fff;}
              break;
            case "011":
              if (action=="s") {runstatus0=runstatus0|0x00004000;} else
              if (action=="r") {runstatus0=runstatus0&0xffffbfff;}
              break;
            case "012":
              if (action=="s") {runstatus0=runstatus0|0x00002000;} else
              if (action=="r") {runstatus0=runstatus0&0xffffdfff;}
              break;
            case "013":
              if (action=="s") {runstatus0=runstatus0|0x00001000;} else
              if (action=="r") {runstatus0=runstatus0&0xffffefff;}
              break;
            case "014":
              if (action=="s") {runstatus0=runstatus0|0x00000800;} else
              if (action=="r") {runstatus0=runstatus0&0xfffff7ff;}
              break;
            case "015":
              if (action=="s") {runstatus0=runstatus0|0x00000400;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffbff;}
              break;
            case "016":
              if (action=="s") {runstatus0=runstatus0|0x00000200;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffdff;}
              break;
            case "017":
              if (action=="s") {runstatus0=runstatus0|0x00000100;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffeff;}
              break;
            case "018":
              if (action=="s") {runstatus0=runstatus0|0x00000080;} else
              if (action=="r") {runstatus0=runstatus0&0xffffff7f;}
              break;
            case "019":
              if (action=="s") {runstatus0=runstatus0|0x00000040;} else
              if (action=="r") {runstatus0=runstatus0&0xffffffbf;}
              break;
            case "01a":
              if (action=="s") {runstatus0=runstatus0|0x00000020;} else
              if (action=="r") {runstatus0=runstatus0&0xffffffdf;}
              break;
            case "01b":
              if (action=="s") {runstatus0=runstatus0|0x00000010;} else
              if (action=="r") {runstatus0=runstatus0&0xffffffef;}
              break;
            case "01c":
              if (action=="s") {runstatus0=runstatus0|0x00000008;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffff7;}
              break;
            case "01d":
              if (action=="s") {runstatus0=runstatus0|0x00000004;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffffb;}
              break;
            case "01e":
              if (action=="s") {runstatus0=runstatus0|0x00000002;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffffd;}
              break;
            case "01f":
              if (action=="s") {runstatus0=runstatus0|0x00000001;} else
              if (action=="r") {runstatus0=runstatus0&0xfffffffe;}
              break;
            case "020":
              if (action=="s") {runstatus1=runstatus1|0x80000000;} else
              if (action=="r") {runstatus1=runstatus1&0x7fffffff;}
              break;
            case "021":
              if (action=="s") {runstatus1=runstatus1|0x40000000;} else
              if (action=="r") {runstatus1=runstatus1&0xbfffffff;}
              break;
            case "022":
              if (action=="s") {runstatus1=runstatus1|0x20000000;} else
              if (action=="r") {runstatus1=runstatus1&0xdfffffff;}
              break;
            case "023":
              if (action=="s") {runstatus1=runstatus1|0x10000000;} else
              if (action=="r") {runstatus1=runstatus1&0xefffffff;}
              break;
            case "024":
              if (action=="s") {runstatus1=runstatus1|0x08000000;} else
              if (action=="r") {runstatus1=runstatus1&0xf7ffffff;}
              break;
            case "025":
              if (action=="s") {runstatus1=runstatus1|0x04000000;} else
              if (action=="r") {runstatus1=runstatus1&0xfbffffff;}
              break;
            case "026":
              if (action=="s") {runstatus1=runstatus1|0x02000000;} else
              if (action=="r") {runstatus1=runstatus1&0xfdffffff;}
              break;
            case "027":
              if (action=="s") {runstatus1=runstatus1|0x01000000;} else
              if (action=="r") {runstatus1=runstatus1&0xfeffffff;}
              break;
            case "028":
              if (action=="s") {runstatus1=runstatus1|0x00800000;} else
              if (action=="r") {runstatus1=runstatus1&0xff7fffff;}
              break;
            case "029":
              if (action=="s") {runstatus1=runstatus1|0x00400000;} else
              if (action=="r") {runstatus1=runstatus1&0xffbfffff;}
              break;
            case "02a":
              if (action=="s") {runstatus1=runstatus1|0x00200000;} else
              if (action=="r") {runstatus1=runstatus1&0xffdfffff;}
              break;
            case "02b":
              if (action=="s") {runstatus1=runstatus1|0x00100000;} else
              if (action=="r") {runstatus1=runstatus1&0xffefffff;}
              break;
            case "02c":
              if (action=="s") {runstatus1=runstatus1|0x00080000;} else
              if (action=="r") {runstatus1=runstatus1&0xfff7ffff;}
              break;
            case "02d":
              if (action=="s") {runstatus1=runstatus1|0x00040000;} else
              if (action=="r") {runstatus1=runstatus1&0xfffbffff;}
              break;
            case "02e":
              if (action=="s") {runstatus1=runstatus1|0x00020000;} else
              if (action=="r") {runstatus1=runstatus1&0xfffdffff;}
              break;
            case "02f":
              if (action=="s") {runstatus1=runstatus1|0x00010000;} else
              if (action=="r") {runstatus1=runstatus1&0xfffeffff;}
              break;
            case "030":
              if (action=="s") {runstatus1=runstatus1|0x00008000;} else
              if (action=="r") {runstatus1=runstatus1&0xffff7fff;}
              break;
            case "031":
              if (action=="s") {runstatus1=runstatus1|0x00004000;} else
              if (action=="r") {runstatus1=runstatus1&0xffffbfff;}
              break;
            case "032":
              if (action=="s") {runstatus1=runstatus1|0x00002000;} else
              if (action=="r") {runstatus1=runstatus1&0xffffdfff;}
              break;
            case "033":
              if (action=="s") {runstatus1=runstatus1|0x00001000;} else
              if (action=="r") {runstatus1=runstatus1&0xffffefff;}
              break;
            case "034":
              if (action=="s") {runstatus1=runstatus1|0x00000800;} else
              if (action=="r") {runstatus1=runstatus1&0xfffff7ff;}
              break;
            case "035":
              if (action=="s") {runstatus1=runstatus1|0x00000400;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffbff;}
              break;
            case "036":
              if (action=="s") {runstatus1=runstatus1|0x00000200;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffdff;}
              break;
            case "037":
              if (action=="s") {runstatus1=runstatus1|0x00000100;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffeff;}
              break;
            case "038":
              if (action=="s") {runstatus1=runstatus1|0x00000080;} else
              if (action=="r") {runstatus1=runstatus1&0xffffff7f;}
              break;
            case "039":
              if (action=="s") {runstatus1=runstatus1|0x00000040;} else
              if (action=="r") {runstatus1=runstatus1&0xffffffbf;}
              break;
            case "03a":
              if (action=="s") {runstatus1=runstatus1|0x00000020;} else
              if (action=="r") {runstatus1=runstatus1&0xffffffdf;}
              break;
            case "03b":
              if (action=="s") {runstatus1=runstatus1|0x00000010;} else
              if (action=="r") {runstatus1=runstatus1&0xffffffef;}
              break;
            case "03c":
              if (action=="s") {runstatus1=runstatus1|0x00000008;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffff7;}
              break;
            case "03d":
              if (action=="s") {runstatus1=runstatus1|0x00000004;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffffb;}
              break;
            case "03e":
              if (action=="s") {runstatus1=runstatus1|0x00000002;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffffd;}
              break;
            case "03f":
              if (action=="s") {runstatus1=runstatus1|0x00000001;} else
              if (action=="r") {runstatus1=runstatus1&0xfffffffe;}
              break;
            default:
              break;
          }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------//

        //Usage:   ....Hub_url..../hub_btc/{154-digit hex-string serialized blocktemplate header ... exclude the cpu/node-id and TOTAL cpu-count number}
        [HttpGet("hub_btc/{str}")]
        public void Mine(int dummy, string str) {
          result="";   result1="";   //should not reset 'runstatusX' hub variables to "0" here, because the value of 'runstatusX' hub variables should be controlled/sent by various CPUs/nodes.
          //cpu_list("set/"+str);    //replace this original line with the code-block below.
          cpucount = (uint) cpu.Length;
          for (uint i=0; i<cpu.Length; i++) {
            using (var myclient = new WebClient()) {
              var responseString = myclient.DownloadString( cpu[i]+"set/"+str+(i.ToString("x3"))+((cpu.Length).ToString("x3")) );   //3 hex-digits of cpu node-id, followed by 3 hex-digits of TOTAL cpu/node count number.
            }
          }
        }

        //Usage:   ....Hub_url..../hub_stop
        [HttpGet("hub_stop")]
        public void Mine(bool dummy) {
          cpu_list("stop");
        }

        //Usage:   ....Hub_url..../hub_cancel
        [HttpGet("hub_cancel")]
        public void Mine(char dummy) {
          cpu_list("set/00000000");
        }

        private static void cpu_list(string str) {
          for (uint i=0; i<cpu.Length; i++) {
            using (var myclient = new WebClient()) {
              var responseString = myclient.DownloadString(cpu[i]+str);
            }
          }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------//



    }
}