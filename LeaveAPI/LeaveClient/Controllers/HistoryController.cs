using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveClient.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult History()
        {
            return View();
        }
    }
}
