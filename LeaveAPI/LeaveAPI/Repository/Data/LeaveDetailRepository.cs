using LeaveAPI.Context;
using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class LeaveDetailRepository : GeneralRepository<MyContext, LeaveDetail, int>
    {
        private readonly MyContext myContext;
        public LeaveDetailRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        private const string url = "https://api-harilibur.vercel.app/api";
        public object[] Get()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("APIKey", "Application/Json");
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<JToken>(data);
            var date = "2021-01-02";
            DateTime myDate = DateTime.Parse(date);
            var holidays = content
                     .Select(team => new Holiday
                     {
                         holiday_date = (DateTime)team["holiday_date"],
                         holiday_name = (string)team["holiday_name"],
                         is_national_holiday = (bool)team["is_national_holiday"]
                     }).Where(a => a.holiday_date == myDate)
                    .ToList();
            List<Object> result = new List<Object>();
            result.Add(holidays);
            return result.ToArray();
        }
        
        public int GetHoliday(DateTime date)
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("APIKey", "Application/Json");
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var content = JsonConvert.DeserializeObject<JToken>(data);
            var holidays = content
                     .Select(team => new Holiday
                     {
                         holiday_date = (DateTime)team["holiday_date"],
                         holiday_name = (string)team["holiday_name"],
                         is_national_holiday = (bool)team["is_national_holiday"]
                     }).Where(a => a.holiday_date == date && a.is_national_holiday == true)
                    .Count();
            if (holidays == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public bool HasExpired(DateTime date)
        {
            DateTime Expires = date;
            return DateTime.Now.CompareTo(Expires.Add(new TimeSpan(2, 0, 0))) > 0;
        }

        public int LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            DateTime StartDate = leaveRequestVM.StartDate;
            DateTime EndDate = leaveRequestVM.EndDate;
            var exp = HasExpired(StartDate);
            if (exp == true)
            {
                return 1;
            }
            else
            {

                int DayInterval = 1;
                int totLeave = 0;

                while (StartDate <= EndDate)
                {

                    var result = GetHoliday(StartDate);

                    if (result > 0)
                    {
                        StartDate = StartDate.AddDays(DayInterval);
                        totLeave += 0;

                    }

                    else
                    {
                        var newDate = StartDate.ToString("dddd");
                        if ((newDate == "Saturday") || (newDate == "Sunday"))
                        {
                            StartDate = StartDate.AddDays(DayInterval);
                            totLeave += 0;
                        }
                        else
                        {
                            StartDate = StartDate.AddDays(DayInterval);
                            totLeave++;

                        }

                    }
                }
                var totalLeaves = myContext.TotalLeaves.Where(a => a.EmployeeId == leaveRequestVM.EmployeeId).ToList();
                var newList = totalLeaves.OrderByDescending(x => x.TotalLeaveId).First();
                if (leaveRequestVM.LeaveTypeId == 1)
                {
                    if (totLeave > newList.EligibleLeave)
                    {
                        return 2;
                    }
                    else
                    {
                        LeaveDetail ld = new LeaveDetail();
                        ld.StartDate = StartDate;
                        ld.EndDate = EndDate;
                        ld.Note = leaveRequestVM.Note;
                        ld.SubmitDate = DateTime.Now;
                        ld.ManagerId = leaveRequestVM.ManagerId;
                        ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
                        ld.EmployeeId = leaveRequestVM.EmployeeId;
                        myContext.Add(ld);
                        myContext.SaveChanges();
                        TotalLeave tl = new TotalLeave();
                        tl.EmployeeId = leaveRequestVM.EmployeeId;
                        tl.EligibleLeave = newList.EligibleLeave - totLeave;
                        tl.TotalLeaves = totLeave + newList.TotalLeaves;
                        myContext.Add(tl);
                        myContext.SaveChanges();
                        return 0;
                    }
                }
                else
                {
                    LeaveDetail ld = new LeaveDetail();
                    ld.StartDate = StartDate;
                    ld.EndDate = EndDate;
                    ld.Note = leaveRequestVM.Note;
                    ld.SubmitDate = DateTime.Now;
                    ld.ManagerId = leaveRequestVM.ManagerId;
                    ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
                    ld.EmployeeId = leaveRequestVM.EmployeeId;
                    myContext.Add(ld);
                    myContext.SaveChanges();
                    TotalLeave tl = new TotalLeave();
                    tl.EmployeeId = leaveRequestVM.EmployeeId;
                    tl.TotalLeaves = totLeave + newList.TotalLeaves;
                    myContext.Add(tl);
                    myContext.SaveChanges();
                    return 0;

                }
            }
        }

        /*public int LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            DateTime StartDate = leaveRequestVM.StartDate;
            DateTime EndDate = leaveRequestVM.EndDate;
            var exp = HasExpired(StartDate);
            if (exp == true)
            {
                return 1;
            }
            else
            {

                int DayInterval = 1;
                int totLeave = 0;

                while (StartDate <= EndDate)
                {

                    var result = GetHoliday(StartDate);

                    if (result > 0)
                    {
                        StartDate = StartDate.AddDays(DayInterval);
                        totLeave += 0;

                    }

                    else
                    {
                        var newDate = StartDate.ToString("dddd");
                        if ((newDate == "Saturday") || (newDate == "Sunday"))
                        {
                            StartDate = StartDate.AddDays(DayInterval);
                            totLeave += 0;
                        }
                        else
                        {
                            StartDate = StartDate.AddDays(DayInterval);
                            totLeave++;

                        }

                    }
                }
                var totalLeaves = myContext.TotalLeaves.Where(a => a.EmployeeId == leaveRequestVM.EmployeeId).ToList();
                var newList = totalLeaves.OrderByDescending(x => x.TotalLeaveId).First();
                if (totLeave > newList.EligibleLeave)
                {
                    return 2;
                }
                else
                {
                    LeaveDetail ld = new LeaveDetail();
                    ld.StartDate = StartDate;
                    ld.EndDate = EndDate;
                    ld.Note = leaveRequestVM.Note;
                    ld.SubmitDate = DateTime.Now;
                    ld.ManagerId = leaveRequestVM.ManagerId;
                    ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
                    ld.EmployeeId = leaveRequestVM.EmployeeId;
                    myContext.Add(ld);
                    myContext.SaveChanges();
                    TotalLeave tl = new TotalLeave();
                    tl.EmployeeId = leaveRequestVM.EmployeeId;
                    tl.EligibleLeave = newList.EligibleLeave - totLeave;
                    tl.TotalLeaves = totLeave + newList.TotalLeaves;
                    myContext.Add(tl);
                    myContext.SaveChanges();
                    return 0;
                }
            }


        }*/

        public int Approve(int key)
        {
            var approve = myContext.LeaveDetails.Where(a => a.EmployeeId == key).ToList();
            LeaveDetail f = approve.OrderByDescending(x => x.LeaveDetailId).First();
            f.Approval = true;
            var result = myContext.SaveChanges();
            return result;
        }

        public Object GetHistory(int Key)
        {
            var result = from emp in myContext.Employees
                         join tl in myContext.TotalLeaves on emp.EmployeeId equals tl.EmployeeId
                         join ld in myContext.LeaveDetails on emp.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         where emp.EmployeeId == Key
                         select new RequesterHistoryVM()
                         {
                             ID = Key,
                             LeaveId = ld.LeaveDetailId,
                             FullName = emp.FirstName + " " + emp.LastName,
                             StartDate = ld.StartDate,
                             EndDate = ld.EndDate,
                             Note = ld.Note,
                             SubmitDate = ld.SubmitDate,
                             Approval = ld.Approval,
                             LeaveTypeName = lt.LeaveTypeName
                         };
            return result;
        }

        public int GetRequestNumber()
        {

            LeaveDetail f = myContext.LeaveDetails.OrderByDescending(x => x.LeaveDetailId).First();
            var number = f.LeaveDetailId + 1;
            return number;
        }
    }
}
