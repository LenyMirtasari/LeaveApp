using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using LeaveClient.Base.Controllers;
using LeaveClient.Repository.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class LeaveDetailsController : BaseController<LeaveDetail, LeaveDetailRepository, int>
    {
        private readonly LeaveDetailRepository repository;
        private readonly IHostingEnvironment hostingEnvironment;
        public LeaveDetailsController(LeaveDetailRepository repository, IHostingEnvironment hostingEnvironment) : base(repository)
        {
            this.repository = repository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult History()
        {
            return View();
        }

        public IActionResult LeaveRequestV()
        {
            return View();
        }

        public IActionResult LeaveManager()
        {
            return View();
        }
        public async Task<JsonResult> GetHistory()
        {
            int id = (int)HttpContext.Session.GetInt32("SessionId");
            var result = await repository.GetHistory(id);
            return Json(result);
        }


        public JsonResult LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            
            string uniqueFileName = null;
            if (leaveRequestVM.File != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + leaveRequestVM.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                leaveRequestVM.File.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            leaveRequestVM.uniqueFileName = uniqueFileName;
            leaveRequestVM.File = null;
            var result = repository.LeaveRequest(leaveRequestVM);
            return Json(result);
        }

        public async Task<JsonResult> GetLeaveDetail(int id)
        {
            var result = await repository.GetLeaveDetail(id);
            return Json(result);
        }



        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(hostingEnvironment.WebRootPath, "files") + "/" + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
          //  return File(bytes, "application/octet-stream", fileName);
        }


    }
}
