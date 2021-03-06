using LeaveAPI.ViewModel;
using LeaveClient.Models;
using LeaveClient.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hostingEnvironment)
        {   

            _logger = logger;
            this.hostingEnvironment = hostingEnvironment;
        }
       
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpPost]
       public IActionResult Create(FileVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.File != null)
                {
                    string uploadsFolder= Path.Combine(hostingEnvironment.WebRootPath, "files");
                    uniqueFileName= Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath =Path.Combine(uploadsFolder, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Coba()
        {
            string filepaths = Path.Combine(hostingEnvironment.WebRootPath, "e1d10ec7-f532-4c62-87be-4a6a8d673c3e_2.PNG");
            List<UploadVM> files = new List<UploadVM>();
           
                files.Add(new UploadVM { FileName = Path.GetFileName(filepaths) });

            
            return View(files);
        }

        public FileResult DownloadFile(string aa)
        {
            string path = Path.Combine(hostingEnvironment.WebRootPath, "files")+"/"+aa ;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", aa);
        }
    }
}
