using System;

namespace app.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // CSGoh stuff are added below.
        public string Message = "Hello there!";
        public uint abc = 10;
        public void OnPost() {
          while (true) {}
          abc++;
          Message = "Button pressed!";
        }
    }
}