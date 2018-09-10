using System;

namespace app.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // CSGoh stuff are added below.
        public string Message = "Hello there!";
        public uint abc = 0;
        public OnPost() {
          abc++;
          Message = "Button pressed!";
        }
    }
}