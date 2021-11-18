using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_T_TotalLeave")]
    public class TotalLeave
    {   [Key]
        public int TotalLeaveId { get; set; }
        public int EligibleLeave { get; set; }
        public int LastYear { get; set; }
        public int TotalLeaves { get; set; }
        public int CurrentYear { get; set; }
        public int LeaveDetailId { get; set; }

        [JsonIgnore]
        public virtual LeaveDetail LeaveDetail { get; set; }
    }
}
