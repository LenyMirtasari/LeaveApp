﻿using LeaveAPI.Context;
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
                if(totLeave > newList.EligibleLeave)
                {
                    return 2;
                }
                else { 
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


        }

        public int ManageBy(ManagerVM managerVM)
        {
            Employee f = myContext.Employees.FirstOrDefault(x => x.EmployeeId == managerVM.EmployeeId);
            f.ManagerId = managerVM.ManagerId;
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
