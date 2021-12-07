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
    public class EmployeeRepository : GeneralRepository<Employee, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public EmployeeRepository(Address address, string request = "Employees/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }

        public async Task<RequesterInfoVM> Requester(int id)
        {
            RequesterInfoVM entity = null;

            using (var response = await httpClient.GetAsync(request + "Requester/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<RequesterInfoVM>(apiResponse);
            }
            return entity;
        }

        public async Task<List<RequesterManagerVM>> RequesterManager(int id)
        {
            List<RequesterManagerVM> entities = new List<RequesterManagerVM>();

            using (var response = await httpClient.GetAsync(request + "RequesterManager/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RequesterManagerVM>>(apiResponse);
            }
            return entities;
        }
   

        public HttpStatusCode Register(RegisterVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "Register/", content).Result;
            return result.StatusCode;
        }

       
    }
}
