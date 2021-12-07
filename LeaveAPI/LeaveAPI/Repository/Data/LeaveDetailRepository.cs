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
        public object[] GetDate()
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
            //return the model to my caller.
            /* return new HoliDate
             {
                 //     Coba = newDate,
                 Holiday = holidays
             };*/
            return result.ToArray();
        }
       /* public async Task<HoliDate> GetHolidaysAsync()
        {
            var client = new RestClient($"https://api-harilibur.vercel.app/api");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                var date = "2021-01-01";
                DateTime myDate = DateTime.Parse(date);
                var newDate = myDate.ToString("dddd");
                //  System.DateTime.Now.ToString("dddd");

                var holidays = content
                     .Select(team => new Holiday
                     {
                         holiday_date = (DateTime)team["holiday_date"],
                         holiday_name = (string)team["holiday_name"],
                         is_national_holiday = (bool)team["is_national_holiday"]
                     }).Where(a => a.holiday_date == myDate)
                    .ToList();

                //return the model to my caller.
                return new HoliDate
                {
                    //     Coba = newDate,
                    Holiday = holidays
                };

            }
            Console.WriteLine(response.Content);

            return null;
        }*/
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
                     }).Where(a => a.holiday_date == date && a.is_national_holiday==true)
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
            var exp= HasExpired(StartDate);
            if (exp== true)
            {
                return 1;
            }
            else { 
                         
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
                        else { 
                            StartDate = StartDate.AddDays(DayInterval);
                            totLeave++;
                           
                        }
                 
                    }
                }
                var totalLeaves = myContext.TotalLeaves.Where(a => a.EmployeeId == leaveRequestVM.EmployeeId).ToList();
                var newList = totalLeaves.OrderByDescending(x => x.TotalLeaveId).First();
                if (leaveRequestVM.LeaveTypeId == 1 ) { 
                    if(totLeave > newList.EligibleLeave)
                    {
                        return 2;
                    }
                    else { 
                        LeaveDetail ld = new LeaveDetail();
                        ld.StartDate = leaveRequestVM.StartDate;
                        ld.EndDate = leaveRequestVM.EndDate;
                        ld.Note = leaveRequestVM.Note;
                        ld.SubmitDate = DateTime.Now;
                        ld.ManagerId = leaveRequestVM.ManagerId;
                        ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
                        ld.EmployeeId = leaveRequestVM.EmployeeId;
                        ld.Approval = Approval.Wait;
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
                    ld.StartDate = leaveRequestVM.StartDate;
                    ld.EndDate = leaveRequestVM.EndDate;
                    ld.Note = leaveRequestVM.Note;
                    ld.SubmitDate = DateTime.Now;
                    ld.ManagerId = leaveRequestVM.ManagerId;
                    ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
                    ld.EmployeeId = leaveRequestVM.EmployeeId;
                    ld.File = leaveRequestVM.uniqueFileName;
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

        public int Approve(int key)
        {
            var f = myContext.LeaveDetails.Where(a => a.LeaveDetailId == key).First();
            f.Approval = Approval.Approve;
            var result = myContext.SaveChanges();
            return result;
        }



        public int Disapprove(int key)
        {
            LeaveDetail f = myContext.LeaveDetails.Where(a => a.LeaveDetailId == key).First();
            f.Approval = Approval.Reject;
            var totalLeaves = myContext.TotalLeaves.Where(a => a.EmployeeId == f.EmployeeId).OrderByDescending(x => x.TotalLeaveId).First();
            var entity = myContext.TotalLeaves.Find(totalLeaves.TotalLeaveId);
            myContext.Remove(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public Object GetHistory(int Key)
        {
            var result = from emp in myContext.Employees
                         join tl in myContext.TotalLeaves on emp.EmployeeId equals tl.EmployeeId
                         join ld in myContext.LeaveDetails on emp.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         where ld.EmployeeId == Key
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

            return result.Distinct().OrderByDescending(x=> x.LeaveId);
        }

        public int GetRequestNumber()
        {
       
            LeaveDetail f = myContext.LeaveDetails.OrderByDescending(x => x.LeaveDetailId).First();
            var number =f.LeaveDetailId +1;
            return number;
        }

        public object GetLeaveDetail(int key)
        {
            var result = from emp in myContext.Employees
                         join job in myContext.Jobs on emp.JobId equals job.JobId
                         join ld in myContext.LeaveDetails on emp.EmployeeId equals ld.EmployeeId
                         join lt in myContext.LeaveTypes on ld.LeaveTypeId equals lt.LeaveTypeId
                         where ld.LeaveDetailId == key 
                         select new LeaveDetailVM()
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
                             LeaveType = lt.LeaveTypeName,
                             FileName = ld.File
                         };

            return result.First();
        }
    }
}
