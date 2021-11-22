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
            Employee e = new Employee();
            var checkData = myContext.Employees.Find(registerVM.EmployeeId);
            var checkPhone = myContext.Employees.Where(employee => employee.PhoneNumber == registerVM.PhoneNumber).FirstOrDefault();
            var checkEmail = myContext.Employees.Where(employee => employee.Email == registerVM.Email).FirstOrDefault();
            e.FirstName = registerVM.FirstName;
            if (checkData != null)
            {
                return 2;
            }

            e.LastName = registerVM.LastName;
            e.PhoneNumber = registerVM.PhoneNumber;
            if (checkPhone != null)
            {
                return 3;
            }

            e.Email = registerVM.Email;
            if (checkEmail != null)
            {
                return 4;
            }

            e.HireDate = registerVM.HireDate;
            e.JobId = 1;
            e.ManagerId = null;
            /*e.Gender = registerVM.Gender;*/
            myContext.Add(e);
            myContext.SaveChanges();

            Account a = new Account();
            a.EmployeeId = e.EmployeeId;
            a.Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password, GetRandomSalt());
            myContext.Add(a);
            myContext.SaveChanges();

            AccountRole ar = new AccountRole();
            ar.EmployeeId = e.EmployeeId;
            ar.RoleId = 1;
            myContext.Add(ar);
            myContext.SaveChanges();

            DateTime today = DateTime.Today;
            var totalDay = (today - registerVM.HireDate).TotalDays;
            var eligibleLeave = 0;
            if (totalDay > 365)
            {
                eligibleLeave = 12;
            }
            else
            {
                eligibleLeave = 0;
            }

            TotalLeave tl = new TotalLeave();
            tl.EmployeeId = e.EmployeeId;
            tl.EligibleLeave = eligibleLeave;
            tl.LastYear = 0;
            tl.TotalLeaves = 0;
            tl.CurrentYear = 0;
            myContext.Add(tl);
            myContext.SaveChanges();
            return 0;
        }

        public int SignManager(int key)
        {
            AccountRole ar = new AccountRole();
            ar.EmployeeId = key;
            ar.RoleId = 1;
            myContext.Add(ar);
            var result = myContext.SaveChanges();
            return result;
        }

        public int ManageBy(ManagerVM managerVM)
        {
            Employee f = myContext.Employees.FirstOrDefault(x => x.EmployeeId == managerVM.EmployeeId);
            f.ManagerId = managerVM.ManagerId;
            var result = myContext.SaveChanges();
            return result;
        }

/*        public IEnumerable<RequesterVM> GetRequester()
        {
            var query = (from e in myContext.Employees
                         join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                         join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                         join r in myContext.Roles on ar.RoleId equals r.RoleId
                         join j in myContext.Jobs on e.JobId equals j.JobId
                         join tl in myContext.TotalLeaves on e.EmployeeId equals tl.EmployeeId
                         join ld in myContext.LeaveDetails on e.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         orderby e.EmployeeId
                         select new RequesterVM
                         {
                             EmployeeId = e.EmployeeId,
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             PhoneNumber = e.PhoneNumber,
                             HireDate = e.HireDate,
                             Email = e.Email,
                             JobId = e.JobId,
                             ManagerId = e.ManagerId,
                             Gender = (ViewModel.Gender)e.Gender,
                             Password = a.Password
                         }).ToList();
            return query;
        }

        public RequesterVM GetRequesterEmployeeId (string EmployeeId)
        {
            var query = (from e in myContext.Employees
                         join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                         join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                         join r in myContext.Roles on ar.RoleId equals r.RoleId
                         join j in myContext.Jobs on e.JobId equals j.JobId
                         join tl in myContext.TotalLeaves on e.EmployeeId equals tl.EmployeeId
                         join ld in myContext.LeaveDetails on e.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         orderby e.EmployeeId
                         select new RequesterVM
                         {
                             NIK = e.NIK,
                             FirstName = e.FirstName,
                             LastName = e.LastName,
                             PhoneNumber = e.PhoneNumber,
                             BirthDate = e.BirthDate,
                             Salary = e.Salary,
                             Email = e.Email,
                             Gender = (ViewModel.Gender)e.Gender,
                             Password = a.Password,
                             Degree = ed.Degree,
                             GPA = ed.GPA,
                             UniversityId = ed.UniversityId,
                             RoleId = r.RoleId
                         }).Where(e => e.NIK == NIK).FirstOrDefault();
            return query;
        }*/

        public int Login(LoginVM loginVM)
        {
            Employee employee = new Employee();
            Account account = new Account();
            var checkEmail = myContext.Employees.Where(employee => employee.Email == loginVM.Email).FirstOrDefault();
            /*var checkEmail = myContext.Employees.Find(loginVM.Email);*/
            if (checkEmail == null)
            {
                return 2;
            }

            var checkPassword = myContext.Accounts.Find(checkEmail.EmployeeId);
            bool validPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, checkPassword.Password);
            if (validPassword)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }


    }
}
