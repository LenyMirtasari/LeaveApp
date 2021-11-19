using LeaveAPI.BaseController;
using LeaveAPI.Context;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository employeeRepository;
        public IConfiguration _configuration;

        private readonly MyContext myContext;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration, MyContext myContext) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this._configuration = configuration;
            this.myContext = myContext;
        }

        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            var result = employeeRepository.Register(registerVM);
            if (result == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal Dimasukkan, Employee ID yang Anda Masukkan Sudah Terdaftar!" });
            }
            else if (result == 3)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal Dimasukkan, Nomor HP yang Anda Masukkan Sudah Terdaftar!" });
            }
            else if (result == 4)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data Gagal Dimasukkan, Email yang Anda Masukkan Sudah Terdaftar!" });
            }
            /*return Ok(new { status = HttpStatusCode.OK, result = result, message = "Data Berhasil Ditambahkan" });*/
            return Ok(result);
        }

    }

}
