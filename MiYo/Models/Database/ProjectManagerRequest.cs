using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class ProjectManagerRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //PM who changed last state
        [Required]
        public string ProjectManagerId { get; set; }
        public virtual ApplicationUser ProjectManager { get; set; }

        [Required]
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

    }
}