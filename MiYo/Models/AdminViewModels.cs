using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MiYo.Models
{
    public class AdminIndexViewModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class AdminRequestViewModel
    {
        public List<EmployeeViewModel> Mentors { get; set; }
        public List<EmployeeViewModel> Mentees { get; set; }
        public List<EmployeeViewModel> SelectedMentors { get; set; }
        public List<EmployeeViewModel> SelectedMentees { get; set; }
    }
}