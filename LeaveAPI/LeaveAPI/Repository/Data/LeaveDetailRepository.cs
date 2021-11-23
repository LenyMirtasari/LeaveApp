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
        public string Get()
        {
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("APIKey", "Application/Json");
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            return data;
        }

        public async Task<HoliDate> GetHolidaysAsync()
        {
            var client = new RestClient($"https://api-harilibur.vercel.app/api");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                var date = "2021-08-17";
                DateTime myDate = DateTime.Parse(date);
                // var holidayCaption = content["holiday_date"].Value<int>();

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
                    Holiday = holidays
                };

            }
            Console.WriteLine(response.Content);

            return null;
        }

        public async Task<int> GetHolidaysAsync(DateTime date)
        {
            var client = new RestClient($"https://api-harilibur.vercel.app/api");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                var holidays = content
                     .Select(team => new Holiday
                     {
                         holiday_date = (DateTime)team["holiday_date"],
                         holiday_name = (string)team["holiday_name"],
                         is_national_holiday = (bool)team["is_national_holiday"]
                     }).Where(a => a.holiday_date == date)
                    .First();
                return 1;
            }
            Console.WriteLine(response.Content);

            return 0;
        }

        public async void LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            LeaveDetail ld = new LeaveDetail();

            ld.StartDate = leaveRequestVM.StartDate;
            ld.EndDate = leaveRequestVM.EndDate;
            ld.Note = leaveRequestVM.Note;
            ld.SubmitDate = DateTime.Now;
            ld.ManagerId = leaveRequestVM.ManagerId;
            ld.LeaveTypeId = leaveRequestVM.LeaveTypeId;
            ld.EmployeeId = leaveRequestVM.EmployeeId;
            myContext.Add(ld);
            myContext.SaveChanges();

            DateTime StartDate = leaveRequestVM.StartDate;
            DateTime EndDate = leaveRequestVM.EndDate;
            int DayInterval = 1;
            int totLeave = 0;
            //List<DateTime> dateList = new List<DateTime>();
            while (StartDate.AddDays(DayInterval) <= EndDate)
            {
                //pengecekan jika ada tanggal libur
                var holiday = await GetHolidaysAsync(StartDate);

                if (holiday == 1)
                {
                    totLeave = totLeave + 0;
                }

                else
                {
                    StartDate = StartDate.AddDays(DayInterval);
                    //dateList.Add(StartDate);
                    totLeave = totLeave + 1;
                }
            }

            TotalLeave tl = new TotalLeave();
            tl.EmployeeId = leaveRequestVM.EmployeeId;
            tl.TotalLeaves = totLeave;
            myContext.Add(tl);
            myContext.SaveChanges();
            // return 1;
            /* var totalLeaves=

             var totalLeave = myContext.TotalLeaves.Where(p => p.EmployeeId == leaveRequestVM.EmployeeId).FirstOrDefault();
             TotalLeave tl = new TotalLeave();
             tl.TotalLeaves = totalLeave.TotalLeaves + 
             myContext.Add(tl);
             myContext.SaveChanges();*/


            /* var newDate = myDate.ToString("dddd");
             DateTime now = DateTime.Now;
*/

        }
    }
}
