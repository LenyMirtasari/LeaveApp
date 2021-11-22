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

        public int GetEmployeeCheck(int Key)
        {
            var datas = myContext.Employees.Find(Key);
            if (datas != null)
            {
                return 1;
            }
            return 0;
        }

        public Object GetProfile(int Key)
        {
            var result = from emp in myContext.Employees                      
                         join job in myContext.Jobs on emp.JobId equals job.JobId
                         join tl in myContext.TotalLeaves on emp.EmployeeId equals tl.EmployeeId
                         where emp.EmployeeId == Key
                         select new RequesterVM()
                         {
                             ID = Key,
                             FullName = emp.FirstName + " " + emp.LastName,                        
                             JobTittle =   job.JobTitle,
                             Email = emp.Email,
                             PhoneNumber = emp.PhoneNumber,
                             ManagerId = emp.ManagerId,
                             EligibleLeave = tl.EligibleLeave,
                             LastYear = tl.LastYear,
                             CurrentYear = tl.CurrentYear,
                             TotalLeaves = tl.TotalLeaves
                         };

            return result;
        }

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
