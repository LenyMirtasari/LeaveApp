using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class HolidayVM
    {
        public DateTime holiday_date { get; set; }
        public string holiday_name { get; set; }
        public bool is_national_holiday { get; set; }
    }
}
