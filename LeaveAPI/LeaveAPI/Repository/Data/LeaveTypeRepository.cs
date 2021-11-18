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
        private readonly MyContext myContext;
        public LeaveTypeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
