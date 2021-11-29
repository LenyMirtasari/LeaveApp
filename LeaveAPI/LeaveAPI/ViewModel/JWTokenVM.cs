using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class JWTokenVM
    {
        public string Messages { get; set; }
        public string Token { get; set; }
        public string[] RoleName { get; set; }
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
    }
}
