using LeaveAPI.BaseController;
using LeaveAPI.Context;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        private readonly EmployeeRepository repository;
        public IConfiguration _configuration;

        private readonly MyContext myContext;
        public EmployeesController(EmployeeRepository employeeRepository, IConfiguration configuration, MyContext myContext) : base(employeeRepository)
        {
            this.repository = employeeRepository;
            this._configuration = configuration;
            this.myContext = myContext;
        }

        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            var result = repository.Register(registerVM);
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
            return Ok(new { status = HttpStatusCode.OK, result = "", message = "Berhasil Memasukkan Data Baru " });
        }

        [Route("SignManager/{Key}")]
        [HttpPost]
        public ActionResult SignManager(int key)
        {
            try
            {
                var result = repository.SignManager(key);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Berhasil di Updated" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Gagal di Update" });
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

        /*[Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var result = repository.GetLogin(loginVM);
            if (result == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, message = "Data gagal dimasukkan : EMAIL yang Anda masukkan TIDAK TERDAFTAR!!!" });
            }
            else if (result == 3)
            {
                *//*var getRoles = repository.GetRole(loginVM.Email);*//*

                var data = new LoginVM()
                {
                    Email = loginVM.Email,
                };

                var claims = new List<Claim>
                {
                    new Claim("Email", data.Email),
                };

                *//*foreach (var item in getRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.ToString()));
                }*//*

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var sigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken
                    (
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: sigIn
                    );

                var idtoken = new JwtSecurityTokenHandler().WriteToken(token);
                claims.Add(new Claim("TokenSecurity", idtoken.ToString()));
                return Ok(new { status = HttpStatusCode.OK, idtoken, message = "Login Berhasil" });
                return Ok(new JWTokenVM
                {
                    *//*status = HttpStatusCode.OK,*//*
                    Token = idtoken,
                    Messages = "Login Berhasil!!"
                });
            }
            else
            {
                return Ok(new { status = HttpStatusCode.BadRequest, message = "Login Gagal" });
            }
        }*/

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

                var data = new LoginDataVM()
                {
                    Email = loginVM.Email,
                };
                var claims = new List<Claim>
                {
                    new Claim("email", data.Email),
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

    }
}
