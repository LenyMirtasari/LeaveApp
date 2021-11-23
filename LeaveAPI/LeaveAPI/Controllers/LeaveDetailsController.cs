using LeaveAPI.BaseController;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using LeaveAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult GetAPI()
        {
            var data = repository.Get();
            return Ok(data);
        }

        [Route("LeaveRequest")]
        [HttpPost]
        public ActionResult LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            var result = repository.LeaveRequest(leaveRequestVM);

            if (result == 1)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Date has passed" });
            }
            else if (result == 2)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = "", message = "Eligible Leave Not Available" });
            }
            else
            {
                return Ok(result);
            }

        }

        [Route("Approve/{Key}")]
        [HttpPost]
        public ActionResult SignManager(int key)
        {
            try
            {
                var result = repository.SignManager(key);
                return Ok(new { status = HttpStatusCode.OK, result, message = "Data Updated" });
            }
            catch (Exception)
            {
                return Ok(new { status = HttpStatusCode.InternalServerError, result = "", message = "Data Update Failed" });
            }
        }
    }
}
