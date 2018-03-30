using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class MentorshipPair
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? MenteeId { get; set; }
        public virtual Employee Mentee { get; set; }

        public int? MentorId { get; set; }
        public virtual Employee Mentor { get; set; }

        [Required]
        public int RequestDirectionId { get; set; }
        public virtual RequestDirection RequestDirection { get; set; }

        [Required]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}