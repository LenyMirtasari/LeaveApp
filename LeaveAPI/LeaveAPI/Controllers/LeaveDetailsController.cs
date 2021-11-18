using LeaveAPI.Base;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    public class LeaveDetailsController : BaseController<LeaveDetail, LeaveDetailRepository, int>
    {
        public LeaveDetailsController(LeaveDetailRepository leaveDetailRepository) : base(leaveDetailRepository)
        {

        }
    }
}
