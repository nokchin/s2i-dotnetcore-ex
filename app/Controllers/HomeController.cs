﻿using System;
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
        public static string result = "";    //the correct nonce value that is wanted (used in the method that has the  [HttpGet("btc")]  attribute).

        public static uint loopcount = 0;
        public static uint run = 0;  // 0 - STOP  .   1 - running .

        [HttpGet("firstloop")]
        public void Mine() {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=1;
          while (run==1) {      // while (true) {
            loopcount++;
            if (loopcount>101) {loopcount=0;}
          }
          loopcount=0;  //this line is very important. Because exiting (getting out of) the loop above means that someone had pressed the 'STOP' button... so loopcount has to be reset to '0'.
        }

/* CSGoh: replace the original code-block below with a new code-block.
        [HttpGet("checkalive")]
        public uint Mine(int abc) {
          return loopcount;
        }                      */
        [HttpGet("checkalive")]
        public IActionResult Mine(int abc) {
          //return loopcount;
          return View();
        }

        [HttpGet("stop")]
        public void Mine(int abc, int def) {    // no 'RETURN' statement is required for a Method that is defined as 'void' type.
          run=0;
        }

        [HttpGet("set/{nonce}")]
        public void Mine(string nonce, int dummy) {
          result = nonce;
        }





        //CSGoh: I performed an experiment in which I choose a  nonce1  value that causes the Method below to run too long and produces the
        //       "504 Timeout Error".  After the "504 Timeout Error" appeared, I waited for some additional/extra time/moment to ensure this Method finishes
        //       running, and then checked the value of 'result' string variable, and found that 'result' really contains the desired nonce value!  So
        //       this shows that the Method below will continue running until it finishes, regardless of whether "504 Timeout Error" comes out or not.
        [HttpGet("btc")]
        public string Mine(string abc) {    // string 'abc'  is a dummy/unused parameter variables -> to differentiate this Method from the rest of other Mine() Methods so that there is no compilation error.

      //CSGoh: the line below can be used to replace the above TWO lines so that we can invoke/call this Method in the 'Mine.cshtml' file using Razor code like this:   @{HomeController.btc();}  . It is just like calling the  @{HomeController.Cats();}  Method in 'All.cshtml' .
//      public static string btc() {    //CSGoh: If I don't use 'static' here, I get this compilation error:   An object reference is required for the non-static field, method, or property.

      result = "";      // reset 'result' to null everytime this Method is called/entered. This is to clear/reset whatever previous nonce value that this string variable may hold/contain.

      uint[] midstate = {0xc022dc5f,0x48274e98,0x6e353555,0x47bfc523,0x4811a092,0x207c9749,0x7657c67e,0x562a335c};
      string bits_expo = "17";   //I have run real cshtml experiment, and found that (unlike in Javascript) string in cshtml must be inside double-quote... cshtml string in single quote will NOT work (based on real experiment).
      string bits_coef = "0x7e578c";
      string merkleroot= "76dc896b48d682e80c6e96368649634e57742a1eeb171dd97c259ce0c6d6a757";
      string mintime = "d1b45d5a";
      string bits = "8c577e17";

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
      string nonce1 = "6d811a13";   // [Value pairs:  0x6e28f2d3 = 1848177363 (decimal,1-million less).  0x6d811a13 = 18337177363 (decimal,12-million less).  0x6b5bc913 = 1801177363 (decimal,48-million less). ]
      string nonce2 = "0";  //I have tested with real cshtml experiment on RedHat OpenShift platform with zero 'nonce2' value, and my cshtml program below can really terminate/exit the 'do-while' loop properly.

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
      midvalue4=midvalue3+blocktemplate;       // reg_e  <-  reg_d + T1
      blocktemplate= blocktemplate+((midvalue0<<30| (midvalue0>>2) )^(midvalue0<<19| (midvalue0>>13) )^(midvalue0<<10| (midvalue0>>22) ))+(midvalue0&midvalue1^midvalue0&midvalue2^midvalue1&midvalue2);       // (T1+T2) = T1 + Sigmabig0(a) + Maj(a,b,c)
      midvalue3=midvalue2;               // reg_d  <-  reg_c
      midvalue2=midvalue1;               // reg_c  <-  reg_b
      midvalue1=midvalue0;               // reg_b  <-  reg_a
      midvalue0=blocktemplate;           // reg_a  <-  (T1+T2)
//    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
}

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
          string str = (reg_e+0x9b05688c).ToString("x8");    // 'str' is now a hex string with 8-characters (with leading zeroes padded if necessary).
          if (str.Substring(6,2)!="00") {break;}
          if (uint.Parse(str.Substring(4,2)+str.Substring(2,2)+str.Substring(0,2),System.Globalization.NumberStyles.HexNumber) < uint.Parse(bits_coef.Substring(2,6),System.Globalization.NumberStyles.HexNumber)) {    //success!


//Javascript:    for (j=0; j<29; j+=4) {  document.write( ((m[3] >>> (28-j)) & 15).toString(16) )  }     //display in hex little-endian. No need to do endianness byte-swap ... just copy exactly whatever displayed here and insert it into the 4-byte nonce field of the header inputs (also in hex little endian) and do submitblock.
//  PHP:         echo dechex($m[3]&0xffffffff);       echo "<BR>";
            result = m[3].ToString("x8");     // the correct/desired nonce value.
            str = "http://two-one.d800.free-int.openshiftapps.com/set/" + result;
            WebRequest myWebRequest = WebRequest.Create(str);    //WebRequest myWebRequest = WebRequest.Create("http://two-one.d800.free-int.openshiftapps.com/set/{nonce}");
            myWebRequest.Method = "GET";
            myWebRequest.ContentLength = TranRequest.Length;
            myWebRequest.ContentType = "application/x-www-form-urlencoded";  //to set content type.
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(myWebRequest.GetRequestStream());  //it will open a http connection with provided url.
            myWriter.Write("");  //send data.
            myWriter.Close();    //closed the myWriter object.
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
  } while (  m[3] != uint.Parse(nonce2,System.Globalization.NumberStyles.HexNumber)   );   //better use hex number here, because Javascript maximum POSITIVE decimal integer/number is until 2,147,483,647 only.
                               //[VERY IMPORTANT]: MUST have ending semicolon at the   "do {} while (...);"   statement. If not, RedHat OpenShift PHP interpreter will give error.


//    blocktemplate = new Audio("buzzer_x.wav"); // buffers automatically when created
//    blocktemplate.play();
      return result;        // ------ NO NEED  'RETURN'  HERE, BECAUSE THIS METHOD IS DEFINED AS  "VOID"  TYPE.  NO COMPILATION ERROR. ------ //
        }







    }
}