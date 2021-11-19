using LeaveAPI.Context;
using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Repository.Data
{
    public class LeaveDetailRepository : GeneralRepository<MyContext, LeaveDetail, int>
    {
        public LeaveDetailRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
