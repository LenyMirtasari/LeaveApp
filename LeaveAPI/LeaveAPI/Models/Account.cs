using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_M_Account")]
    public class Account
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public virtual Employee Employee { get; set; }
        [JsonIgnore]
        public virtual ICollection<AccountRole> AccountRole { get; set; }
    }
}
