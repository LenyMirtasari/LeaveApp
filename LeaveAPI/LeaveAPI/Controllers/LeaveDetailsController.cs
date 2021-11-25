using LeaveAPI.Base;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
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
        public ActionResult GetAPI()
        {
            var data = repository.Get();
            return Ok(data);
        }

/*        [Route("Holiday")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync() { 
        var model = await repository.GetHolidaysAsync();

        if (model == null)
            return NotFound(); 

        return Ok(model);
        }*/

        [Route("LeaveRequest")]
        [HttpPost]
        public ActionResult LeaveRequest(LeaveRequestVM leaveRequestVM)  
        {
            var result =repository.LeaveRequest(leaveRequestVM);

            if (result==1)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Date has passed" });
            }
            else if (result == 2)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = "", message = "Eligible Leave Not Available" });
            }
            else
            {
                return Ok(result);
            }
            
        }

        [Route("Approve/{Key}")]
        [HttpPut]
        public ActionResult Approve(int key)
        {
            try
            {
                var result = repository.Approve(key);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Updated" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Update Failed" });
            }
        }

        [Route("GetHistory/{Key}")]
        [HttpGet]
        public ActionResult GetHistory(int key)
        {
            var data = repository.GetHistory(key);
            return Ok(data);
        }

        [Route("GetRequestNumber")]
        [HttpGet]
        public ActionResult GetRequestNumber()
        {
            var data = repository.GetRequestNumber();
            return Ok(data);
        }


    }
}
