﻿using LeaveAPI.Context;
using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<MyContext, AccountRole, int>
    {
        public AccountRoleRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
