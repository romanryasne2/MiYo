using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MiYo.Models
{
    public class UserIndexViewModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}