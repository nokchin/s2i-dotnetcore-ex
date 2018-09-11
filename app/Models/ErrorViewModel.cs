using System;

namespace app.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // CSGoh stuff are added below.
        public string Message = "Hello there!";
        static uint abc = 10;
        public void OnPost() {
          abc++;
          Message = "Button pressed!";
        }
    }
}