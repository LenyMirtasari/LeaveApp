using LeaveAPI.Base;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository repository;
        public IConfiguration _configuration;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration) : base(employeeRepository)
        {
            this.repository = employeeRepository;
            this._configuration = configuration;
        }

        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            var validasi = repository.Register(registerVM);
            if (validasi == 1)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "Internal Server Error", message = "NIK Sudah Terdafar" });
            }
            else if (validasi == 2)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "Internal Server Error", message = "Email Sudah Terdafar" });
            }
            else if (validasi == 3)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "Internal Server Error", message = "Phone Number Sudah Terdafar" });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.OK, result = "", message = "Berhasil Memasukkan Data Baru " });
            }
        }

        [Route("SignManager/{Key}")]
        [HttpPost]
        public ActionResult SignManager(int key)
        {
            try
            {
                var result = repository.SignManager(key);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Updated" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Update Failed" });
            }
        }

        [Route("ManageBy")]
        [HttpPut]
        public ActionResult ManageBy(ManagerVM managerVM)
        {
            try
            {
                var result = repository.ManageBy(managerVM);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Updated" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Update Failed" });
            }
        }
    }
}
