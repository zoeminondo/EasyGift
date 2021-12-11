using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace EasyGift.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int numTimes = 1)
            {
                return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            }
    }
}