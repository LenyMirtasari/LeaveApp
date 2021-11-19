using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_M_Job")]
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
