using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class RequesterManagerVM
    {
        public int LeaveDetailId { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string JobTittle { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime SubmitDate{ get; set; }
        public bool Approval { get; set; }

    }
}
