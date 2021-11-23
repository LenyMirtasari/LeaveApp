using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class LeaveRequestVM
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ManagerId { get; set; }
        //  public string ManagerName { get; set; }
        public int LeaveTypeId { get; set; }
        public string Note { get; set; }
    }
}
