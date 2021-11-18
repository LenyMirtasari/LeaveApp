using LeaveAPI.Base;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    public class EmployeesController : BaseController<Employee, EmployeeRepository, int>
    {
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }
    }
}
