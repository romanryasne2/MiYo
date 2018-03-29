using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [Required]
        public double Rating { get; set; }

        [Required]
        public byte[] Avatar { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}