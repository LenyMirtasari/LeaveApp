using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class RequesterHistoryVM
    {
        public int ID { get; set; }
        public int LeaveId { get; set; }

        public string FullName { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Note { get; set; }

        public DateTime SubmitDate { get; set; }

        public bool Approval { get; set; }

        public string LeaveTypeName { get; set; }
    }
}
