using LeaveAPI.Context;
using LeaveAPI.Models;
using Newtonsoft.Json;
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
    }
}
