﻿using LeaveAPI.Context;
using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class JobRepository : GeneralRepository<MyContext, Job, int>
    {
        public JobRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
