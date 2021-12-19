using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;



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

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello evrybody " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
            
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            
            if (file == null){

                    return View();
            }

            else{
                
                string adresseEasyGift = Directory.GetCurrentDirectory();
                using var image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(256, 256));
                // Il faut changer le nom de la photo
                image.Save(adresseEasyGift+"/wwwroot/images/filename.jpg");
                
                return Ok();

            }
            
        }
    }
}