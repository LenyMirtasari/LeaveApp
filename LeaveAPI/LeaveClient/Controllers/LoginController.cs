using LeaveAPI.ViewModel;
using LeaveClient.Base.Controllers;
using LeaveClient.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class LoginController : BaseController<LoginVM, LoginRepository, string>
    {
        private readonly LoginRepository repository;
        public LoginController(LoginRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwtToken = await repository.Auth(login);
            var token = jwtToken.Token;
            var roleName = jwtToken.RoleName;
            var employeeId = jwtToken.EmployeeId.ToString();
          
           // int aa = roleName.Count();
            if (token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("JWToken", employeeId);
            if (roleName.Count()==2)
            {
                return RedirectToAction("LeaveManager", "Employees" );
            }

            /*foreach (var a in roleName)
            {
                if (a == "Employee, Manager")
                {
                    return RedirectToAction("LeaveRequestV", "History");
                }
            }*/

            return RedirectToAction("Index", "Users");
        }

        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}
