using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Culture { get; set; }

        [ForeignKey("LanguageId")]
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }

        [ForeignKey("LanguageId")]
        public virtual ICollection<Request> Requests { get; set; }
    }
}