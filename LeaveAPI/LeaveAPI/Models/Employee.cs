using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    [Table("Tb_T_Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }
        public int? ManagerId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

        [JsonIgnore]
        public virtual Job Job { get; set; }

        [JsonIgnore]
        public virtual ICollection<LeaveDetail> LeaveDetailEmployee { get; set; }

        [JsonIgnore]
        public virtual ICollection<LeaveDetail> LeaveDetailManager { get; set; }

        [JsonIgnore]
        public virtual ICollection<TotalLeave> TotalLeave { get; set; }

        public Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }

    }

    public enum Gender
    {
        Male,
        Female
    }
}
