using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LeaveAPI.Models
{
    public class HoliDate
    {   
      /*  public int HolidayCaption { get; set; }*/
   
        public IEnumerable<Holiday> Holiday { get; set; }
    }
}
