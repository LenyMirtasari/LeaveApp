using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    public class Holiday
    {
        public DateTime holiday_date { get; set; }
        public string holiday_name { get; set; }
        public bool is_national_holiday { get; set; }
    }
}
