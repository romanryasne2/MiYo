using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class EmployeeSkillState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EmployeeSkillId { get; set; }
        public virtual EmployeeSkill EmployeeSkill { get; set; }

        [Required]
        public int SkillStateId { get; set; }
        public virtual SkillState SkillState { get; set; }
    }
}