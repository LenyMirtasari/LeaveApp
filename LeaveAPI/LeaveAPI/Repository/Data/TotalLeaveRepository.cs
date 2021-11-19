using LeaveAPI.Context;
using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class TotalLeaveRepository : GeneralRepository<MyContext, TotalLeave, int>
    {
        public TotalLeaveRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
