using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_T_LeaveDetail")]
    public class LeaveDetail
    {   [Key]
        public int LeaveDetailId { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Note { get; set; }

        public DateTime SubmitDate { get; set; }

        public bool Approval { get; set; }

        public int ManagerId { get; set; }

        public int LeaveTypeId { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual Employee Manager{ get; set; }
        [JsonIgnore]
        public virtual TotalLeave TotalLeave{ get; set; }
        [JsonIgnore]
        public virtual LeaveType LeaveType{ get; set; }
    }
}
