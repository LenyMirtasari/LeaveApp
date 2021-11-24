using LeaveAPI.Models;
using LeaveAPI.ViewModel;
using LeaveClient.Base.Controllers;
using LeaveClient.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class LeaveDetailsController : BaseController<LeaveDetail, LeaveDetailRepository, int>
    {
        private readonly LeaveDetailRepository repository;
        public LeaveDetailsController(LeaveDetailRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult History()
        {
            return View();
        }

        public IActionResult LeaveRequestV()
        {
            return View();
        }
        public async Task<JsonResult> GetHistory(int id)
        {
            var result = await repository.GetHistory(id);
            return Json(result);
        }

        public JsonResult LeaveRequest(LeaveRequestVM leaveRequestVM)
        {
            var result = repository.LeaveRequest(leaveRequestVM);
            return Json(result);
        }
    }
}
