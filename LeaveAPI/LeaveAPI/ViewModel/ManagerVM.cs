using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class ManagerVM
    {
        [Required(ErrorMessage = "Please enter Employee Id")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter Manager Id")]
        public int ManagerId { get; set; }
    }
}
