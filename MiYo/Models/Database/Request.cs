using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiYo.Models.Database
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        [Required]
        public int StateId { get; set; }
        public virtual RequestState State { get; set; }

        //Describes why state was changed
        public string StateReason { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public string Description { get; set; }


        [ForeignKey("RequestId")]
        public virtual ICollection<MentorshipPair> MentorshipPairs { get; set; }

        [ForeignKey("RequestId")]
        public virtual ICollection<ProjectManagerRequest> ProjectManagerRequests { get; set; }
    }
}