using LeaveAPI.Context;
using LeaveAPI.Models;
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
    }
}
