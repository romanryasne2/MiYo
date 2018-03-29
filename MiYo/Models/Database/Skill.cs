using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [ForeignKey("SkillId")]
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        [ForeignKey("SkillId")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}