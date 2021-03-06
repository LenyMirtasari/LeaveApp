using LeaveAPI.Context;
using LeaveAPI.Models;
using LeaveAPI.PasswordHashing;
using LeaveAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, int>
    {
        private readonly MyContext myContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(RegisterVM registerVM)
        {
            Employee e = new Employee();
            e.FirstName = registerVM.FirstName;
            e.LastName = registerVM.LastName;
            e.Email = registerVM.Email;
            e.PhoneNumber = registerVM.PhoneNumber;
            e.HireDate = registerVM.HireDate;
            e.JobId = 1;
            e.ManagerId = null;
            e.Gender = registerVM.Gender;
            myContext.Add(e);
            myContext.SaveChanges();
          
            Account a = new Account();
            a.EmployeeId = e.EmployeeId;
            a.Password = Hashing.HashPassword(registerVM.Password);
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
                if (totalDay> 365)
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

        public Object GetRequester(int Key)
        {
            var result = from emp in myContext.Employees                      
                         join job in myContext.Jobs on emp.JobId equals job.JobId
                         join tl in myContext.TotalLeaves on emp.EmployeeId equals tl.EmployeeId
                         where tl.EmployeeId == Key
                         select new RequesterInfoVM()
                         {
                             ID = Key,
                             FullName = emp.FirstName + " " + emp.LastName,                        
                             JobTittle =   job.JobTitle,
                             Email = emp.Email,
                             PhoneNumber = emp.PhoneNumber,
                             ManagerId = emp.ManagerId,
                             ManagerName = (from e in myContext.Employees where e.EmployeeId == emp.ManagerId select e.FirstName).FirstOrDefault()+" "+
                             (from e in myContext.Employees where e.EmployeeId == emp.ManagerId select e.LastName).FirstOrDefault()
                             ,
                             TotalLeaveId = tl.TotalLeaveId,
                             EligibleLeave = tl.EligibleLeave,
                             LastYear = tl.LastYear,
                             CurrentYear = tl.CurrentYear,
                             TotalLeaves = tl.TotalLeaves
                         };
           
            return result.OrderByDescending(x=>x.TotalLeaveId).First();
        }

        public Object GetRequesterManager(int Key)
        {
            var result = from emp in myContext.Employees
                         join job in myContext.Jobs on emp.JobId equals job.JobId
                         join ld in myContext.LeaveDetails on emp.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         where ld.ManagerId == Key && ld.Approval == 0
                         select new RequesterManagerVM()
                         {
                             LeaveDetailId = ld.LeaveDetailId, 
                             EmployeeId = emp.EmployeeId,
                             FullName = emp.FirstName + " " + emp.LastName,
                             JobTittle = job.JobTitle,
                             Email = emp.Email,
                             PhoneNumber = emp.PhoneNumber,
                             SubmitDate = ld.SubmitDate,
                             Approval = ld.Approval,
                             StartDate = ld.StartDate,
                             EndDate = ld.EndDate,
                             Note = ld.Note,
                             LeaveType = lt.LeaveTypeName
                         };

            return result;
        }

        public int GetLogin(string emailInput, string passwordInput)
        {
            try
            {
                var checkEmail = myContext.Employees.Where(p => p.Email == emailInput).FirstOrDefault();
                var id = (from emp in myContext.Employees where emp.Email == emailInput select emp.EmployeeId).Single();
                var password = (from emp in myContext.Employees
                                join acc in myContext.Accounts on emp.EmployeeId equals acc.EmployeeId
                                where emp.Email == emailInput
                                select acc.Password).Single();
                var validPw = Hashing.ValidatePassword(passwordInput, password);
                if (checkEmail != null)
                {
                    if (validPw == true)
                    {
                        return 0;

                    }
                    else if (validPw == false)
                    {
                        return 2;
                    }

                }
            }
            catch (InvalidOperationException)
            {
                return 1;
            }
            return 3;
        }

        public string[] GetUserRole(LoginVM loginVM)
        {
            var id = (from emp in myContext.Employees where emp.Email == loginVM.Email select emp.EmployeeId).FirstOrDefault();
            var roles = myContext.AccountRoles.Where(a => a.EmployeeId == id).ToList();
            List<string> result = new List<string>();
            foreach (var item in roles)
            {
                result.Add(myContext.Roles.Where(a => a.RoleId == item.RoleId).First().RoleName);
            }
            return result.ToArray();
        }
        public int GetEmployeeId(LoginVM loginVM)
        {
            var id = (from emp in myContext.Employees where emp.Email == loginVM.Email select emp.EmployeeId).FirstOrDefault();         
            return id;
        }

        public string GetEmployeeName(LoginVM loginVM)
        {
            string name = (from emp in myContext.Employees where emp.Email == loginVM.Email select emp.FirstName+" "+emp.LastName).FirstOrDefault();
            return name;
        }

        public Object ManagerEmail(int key)
        {
            var managerId = (from emp in myContext.Employees where emp.EmployeeId == key select emp.ManagerId).FirstOrDefault();
            var email = (from emp in myContext.Employees where emp.EmployeeId == managerId select new EmailVM() { Email= emp.Email }).FirstOrDefault();
            return email;
        }
    
        public Object EmployeeEmail(int key)
        {
            var employeeId = (from ld in myContext.LeaveDetails where ld.LeaveDetailId == key select ld.EmployeeId).FirstOrDefault();
            var email = (from emp in myContext.Employees where emp.EmployeeId == employeeId select new EmailVM() { Email = emp.Email }).FirstOrDefault();
            return email;
        }
    }
}
