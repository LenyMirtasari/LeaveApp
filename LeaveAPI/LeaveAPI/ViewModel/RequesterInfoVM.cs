using LeaveAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class RequesterInfoVM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string JobTittle { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int TotalLeaveId { get; set; }
        public int EligibleLeave { get; set; }
        public int LastYear { get; set; }
        public int CurrentYear { get; set; }
        public int TotalLeaves { get; set; }
        
      
    }
}
