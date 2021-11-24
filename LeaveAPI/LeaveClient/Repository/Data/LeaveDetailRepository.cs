using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using LeaveClient.Base.Urls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeaveClient.Repository.Data
{
    public class LeaveDetailRepository : GeneralRepository<LeaveDetail, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public LeaveDetailRepository(Address address, string request = "LeaveDetails/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }

        public async Task<List<RequesterHistoryVM>> GetHistory(int id)
        {
            List<RequesterHistoryVM> entities = new List<RequesterHistoryVM>();

            using (var response = await httpClient.GetAsync(request + "GetHistory/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RequesterHistoryVM>>(apiResponse);
            }
            return entities;
        }

        /* public HttpStatusCode LeaveRequest(LeaveRequestVM entity)
         {
             StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
             var result = httpClient.PostAsync(address.link + request + "LeaveRequest/", content).Result;
             return result.StatusCode;
         }*/

        public HttpStatusCode LeaveRequest(LeaveRequestVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "LeaveRequest/", content).Result;
            return result.StatusCode;
        }
    }
}
