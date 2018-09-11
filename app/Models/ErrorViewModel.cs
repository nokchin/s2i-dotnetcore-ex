using System;
using Microsoft.AspNetCore.Mvc;                //CSGoh: I add in this line.
using Microsoft.AspNetCore.Mvc.RazorPages;     //CSGoh: I add in this line.


namespace app.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // CSGoh stuff are added below.
        public string Message = "Hello there!";
        public uint abc = 10;
        public PageResult OnPost() {
          while (true) {}      //not executed... don't know why?
          abc++;
          Message = "Button pressed!";
        }
    }
}