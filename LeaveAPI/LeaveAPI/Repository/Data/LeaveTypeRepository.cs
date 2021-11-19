using LeaveAPI.Context;
using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class LeaveTypeRepository : GeneralRepository<MyContext, LeaveType, int>
    {
        public LeaveTypeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
