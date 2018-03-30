using MiYo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiYo.Models
{
    public class DatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var RequestDirections = new List<RequestDirection>
            {
            new RequestDirection{Name="ToMentee"},
            new RequestDirection{Name="ToMentor"}
            };

            RequestDirections.ForEach(s => context.RequestDirections.Add(s));
            context.SaveChanges();
            var RequestStates = new List<RequestState>
            {
            new RequestState{Name="InProgres"},
            new RequestState{Name="Canceled"},
            new RequestState{Name="Accepted"}
            };
            RequestStates.ForEach(s => context.RequestStates.Add(s));
            context.SaveChanges();
            var Roles = new List<Role>
            {
            new Role{Name="Employee"},
            new Role{Name="Admin"}
            };
            Roles.ForEach(s => context.UserRoles.Add(s));
            context.SaveChanges();
            var SkillStates = new List<SkillState>
            {
            new SkillState{Name="Not learning"},
            new SkillState{Name="Learning"},
            new SkillState{Name="Teaching"},
            new SkillState{Name="Want to learn"},
            new SkillState{Name="Want to teach"},
            };
            SkillStates.ForEach(s => context.SkillStates.Add(s));
            context.SaveChanges();
        }
    }
}