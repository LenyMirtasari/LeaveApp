using LeaveAPI.Context;
using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, int>
    {
        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            Employee employee = new Employee();
            AccountRole accountRole = new AccountRole();
            Role role = new Role();
            var checkData = myContext.Employees.Find(registerVM.EmployeeId);
            var checkPhone = myContext.Employees.Where(employee => employee.PhoneNumber == registerVM.PhoneNumber).FirstOrDefault();
            var checkEmail = myContext.Employees.Where(employee => employee.Email == registerVM.Email).FirstOrDefault();
            employee.EmployeeId = registerVM.EmployeeId;
            if (checkData != null)
            {
                return 2;
            }

            employee.FirstName = registerVM.FirstName;
            employee.LastName = registerVM.LastName;
            employee.PhoneNumber = registerVM.PhoneNumber;
            if (checkPhone != null)
            {
                return 3;
            }

            employee.HireDate = registerVM.HireDate;
            employee.Email = registerVM.Email;
            employee.Gender = (Models.Gender)registerVM.Gender;
            if (checkEmail != null)
            {
                return 4;
            }
            myContext.Employees.Add(employee);
            myContext.SaveChanges();

            Account account = new Account();
            account.EmployeeId = registerVM.EmployeeId;
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password, GetRandomSalt());
            myContext.Accounts.Add(account);
            myContext.SaveChanges();

            accountRole.EmployeeId = account.EmployeeId;
            /*accountRole.RoleId = registerVM.RoleId;*/
            myContext.AccountRoles.Add(accountRole);
            var result = myContext.SaveChanges();

            return result;
        }

    }
}
