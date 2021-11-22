using LeaveAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveAPI.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter the hire date")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "Please enter the job Id")]
        public int JobId { get; set; }
        public int? ManagerId { get; set; }

        [Required(ErrorMessage = "Please enter your gender")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
        public int EligibleLeave { get; set; }
        public int LastYear { get; set; }
        public int TotalLeaves { get; set; }
        public int CurrentYear { get; set; }
        public int EmployeeId { get; set; }
    }

    /*public enum Gender
    {
        Male,
        Female
    }*/
}
