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

        public async Task<JsonResult> Requester()
        {
            int id = (int)HttpContext.Session.GetInt32("SessionId");
            var result = await repository.Requester(id);
            return Json(result);
        }

        public async Task<JsonResult> ManagerEmail()
        {
            int id = (int)HttpContext.Session.GetInt32("SessionId");
            var result = await repository.ManagerEmail(id);
            return Json(result);
        }

        public async Task<JsonResult> EmployeeEmail(int id)
        {
            var result = await repository.EmployeeEmail(id);
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
      
        public void SendEmailToManager(string email, string sd, string ed, string note, string lt, string mng)
        {
            string name = HttpContext.Session.GetString("FullName");
            string date=  DateTime.Now.ToString("MMddyyyy");
            DateTime myDate = DateTime.Parse(sd);
            string sd1 = myDate.ToString("dd MMMM yyyy");
            DateTime myDate1 = DateTime.Parse(ed);
            string ed1 = myDate1.ToString("dd MMMM yyyy");
            Random rnd = new Random();
            int card = rnd.Next(52);
            int card1 = rnd.Next(52);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("leaverequest12@gmail.com");
                mail.To.Add(email);
                mail.Subject = "[Request] Leave "+name+" "+ date+card+card1;
                mail.Body = " <p>Kepada, <span><b>"+mng+ "</b></span></p> <p>Dengan ini karyawan atas nama <span>"+name+
                    "</span> ingin melakukan cuti pada:</p> <p>&emsp;&emsp;&emsp;Tanggal  : <span><b>"+sd1+" - "+ed1+
                    "</b></span></p> <p>&emsp;&emsp;&emsp;Kategori : <span><b>"+lt+ 
                    "</b></span></p> <p>&emsp;&emsp;&emsp;Alasan   : <span><b>"+note+ "</b></span></p> <p>Terima kasih,</p> <p>Leave Request Application</p>";


                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("leaverequest12@gmail.com", "Leaverequest321!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

        public void SendEmailToEmployee(string email, string nm, string status, string sd, string ed, string lt)
        {
            string name = HttpContext.Session.GetString("FullName");
            string date = DateTime.Now.ToString("MMddyyyy");
            DateTime myDate = DateTime.Parse(sd);
            string sd1 = myDate.ToString("dd MMMM yyyy");
            DateTime myDate1 = DateTime.Parse(ed);
            string ed1 = myDate1.ToString("dd MMMM yyyy");
            Random rnd = new Random();
            int card = rnd.Next(52);
            int card1 = rnd.Next(52);

            using (MailMessage mail = new MailMessage())
            {   
                mail.From = new MailAddress("leaverequest12@gmail.com");
                mail.To.Add(email);
                mail.Subject = "[Request] Leave " + name + " " + date + card + card1;
                mail.Body = "<p>Kepada, <span><b>"+nm+ "</b></span></p> <p>Dengan ini permintaan cuti karyawan atas nama <span><b>"+nm+
                    "</b></span> pada :</p> <p>&emsp;&emsp;&emsp;Tanggal : <span><b>"+sd1+" - "+ed1+
                    "</b></span></p> <p>&emsp;&emsp;&emsp;Kategori : <span><b>"+lt+
                    "</b></span></p>  <p>telah <b>"+status+ "</b> sesuai dengan peraturan perusahaan yang berlaku.</p><p>Terima kasih,</p><p>Leave Request Application</p>";
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("leaverequest12@gmail.com", "Leaverequest321!");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

        }

     
    }
}
