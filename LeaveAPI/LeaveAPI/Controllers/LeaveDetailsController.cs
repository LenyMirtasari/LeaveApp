using LeaveAPI.BaseController;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveDetailsController : BaseController<LeaveDetail, LeaveDetailRepository, int>
    {
        private readonly LeaveDetailRepository repository;
        public IConfiguration _configuration;
        public LeaveDetailsController(LeaveDetailRepository leaveDetailRepository, IConfiguration configuration) : base(leaveDetailRepository)
        {
            this.repository = leaveDetailRepository;
            this._configuration = configuration;
        }

        [Route("GetAPI")]
        [HttpGet]
        public string GetAPI()
        {
            var data = repository.Get();
            return data;
        }

        /*[Route("Holiday")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync()
        {
            var model = await repository.GetHolidaysAsync();

            if (model == null)
                return NotFound();

            return Ok(model);
        }*/
    }
}
