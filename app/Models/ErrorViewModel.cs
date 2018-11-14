using System;
using Microsoft.AspNetCore.Mvc;                //CSGoh: I add in this line.
using Microsoft.AspNetCore.Mvc.RazorPages;     //CSGoh: I add in this line.


namespace app.Models
{
    public class ErrorViewModel {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}