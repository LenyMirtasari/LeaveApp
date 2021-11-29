using LeaveAPI.Base;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
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

        [Route("Requester/{Key}")]
        [HttpGet]
        public ActionResult Requester(int Key)
        {
            var check = repository.GetEmployeeCheck(Key);
            if (check == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Data Not Found " });
            }
            else
            {
                var result = repository.GetRequester(Key);
                return Ok(result);
            }
        }

        [Route("RequesterManager/{Key}")]
        [HttpGet]
        public ActionResult RequesterManager(int Key)
        {
            var check = repository.GetEmployeeCheck(Key);
            if (check == 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Data Not Found " });
            }
            else
            {
                var result = repository.GetRequesterManager(Key);
                return Ok(result);
            }
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var check = repository.GetLogin(loginVM.Email, loginVM.Password);

            if (check == 1)
            {
                return BadRequest(new JWTokenVM { Messages = "Email/Password Salah", Token = null });

            }
            else if (check == 2)
            {
                return BadRequest(new JWTokenVM { Messages = "Email/Password Salah", Token = null });
            }
            else
            {
                var getUserRoles = repository.GetUserRole(loginVM);
                var EmployeeId = repository.GetEmployeeId(loginVM).ToString();
                var data = new LoginDataVM()
                {
                    Email = loginVM.Email,
                };

                var claims = new List<Claim>
                {
                    new Claim("email", data.Email),
                    new Claim("employeeId", EmployeeId)
                };
                foreach (var a in getUserRoles)
                {
                    claims.Add(new Claim("roles", a.ToString()));

                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn
                            );
                var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                return Ok(new JWTokenVM
                {
                    Messages = "Login Berhasil",
                    Token = idtoken,
                    RoleName = repository.GetUserRole(loginVM),
                    EmployeeId = repository.GetEmployeeId(loginVM)
                });
            }

        }

        [Authorize]
        [HttpGet("TestJWT")]
        public ActionResult TestJWT()
        {
            return Ok("Test JWT berhasil");
        }

        [Route("ManagerEmail/{Key}")]
        [HttpGet]
        public ActionResult ManagerEmail(int Key)
        {
            var result = repository.ManagerEmail(Key);
            return Ok(result);
        }

        [Route("EmployeeEmail/{Key}")]
        [HttpGet]
        public ActionResult EmployeeEmail(int Key)
        {
            var result = repository.EmployeeEmail(Key);
            return Ok(result);
        }
    }
}
