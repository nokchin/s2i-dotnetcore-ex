using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LearnRazorPages.Pages {
  public class IndexModel : PageModel {
    public string Message { get; set; } = "PageModel in C#";
//  public string Message = "Original";
//  public void OnGet() {Message="New Message!";}
  }
}
