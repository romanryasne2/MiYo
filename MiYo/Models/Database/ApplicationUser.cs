using Microsoft.AspNet.Identity.EntityFramework;
using MiYo.Models.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("ProjectManagerId")]
        public virtual ICollection<ProjectManagerRequest> ProjectManagerRequests { get; set; }
    }
}