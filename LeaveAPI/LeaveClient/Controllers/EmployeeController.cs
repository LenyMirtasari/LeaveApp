using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using LeaveClient.Base.Controllers;
using LeaveClient.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository repository;
        public EmployeesController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<JsonResult> Requester(int id)
        {
            var result = await repository.Requester(id);
            return Json(result);
        }
        
        public async Task<JsonResult> RequesterManager()
        {
            int id = (int)HttpContext.Session.GetInt32("SessionId");
            var result = await repository.RequesterManager(id);
            return Json(result);
        }

        public JsonResult Register(RegisterVM registerVM)
        {
            var result = repository.Register(registerVM);
            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }

     
        [Authorize(Roles = "Manager")]
        public IActionResult LeaveManager()
        {
            return View();
        }

        public int SendEmail()
        {

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("leaverequest12@gmail.com");
                mail.To.Add("bunnystory93@gmail.com");
                mail.Subject = "Test";
                mail.Body = "<h1>Coba lagi</h1>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("leaverequest12@gmail.com", "Leaverequest321!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return 1;
                }
            }

        }
    }
}
