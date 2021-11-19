using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_M_LeaveType")]
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public int Day { get; set; }

        [JsonIgnore]
        public virtual ICollection<LeaveDetail> LeaveDetail { get; set; }
    }
}
