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
    public class TotalLeavesController : BaseController<TotalLeave, TotalLeaveRepository, int>
    {
        public TotalLeavesController(TotalLeaveRepository totalLeaveRepository) : base(totalLeaveRepository)
        {

        }
    }
}
