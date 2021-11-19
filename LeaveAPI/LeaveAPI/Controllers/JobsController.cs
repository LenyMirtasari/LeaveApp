﻿using LeaveAPI.BaseController;
using LeaveAPI.Models;
using LeaveAPI.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : BaseController<Job, JobRepository, int>
    {
        public JobsController(JobRepository jobRepository) : base(jobRepository)
        {

        }
    }
}
