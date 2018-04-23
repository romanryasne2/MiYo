using MiYo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiYo.Models
{
    public class EmployeeViewModel
    {
        /// <summary>
        /// Fills data from db by specified id of Employee
        /// </summary>
        public static EmployeeViewModel FillById(int id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            using (var db = new ApplicationDbContext())
            {
                employee.Id = id;

                var user = db.Users.Where(u => u.EmployeeId == id).FirstOrDefault();
                employee.FirstName = user.FirstName;
                employee.LastName = user.LastName;
                employee.Email = user.Email;

                var emp = db.Employees.Where(e => e.Id == id).FirstOrDefault();
                employee.Location = db.Locations.Where(l => l.Id == emp.LocationId).FirstOrDefault();
                employee.Job = db.EmployeeJobs.Join(
                    db.Jobs,
                    ej => ej.JobId,
                    j => j.Id,
                    (ej, j) => new { ej.EmployeeId, Job = j.Name }).
                    Where(ej => ej.EmployeeId == id).
                    Select(ej => ej.Job).FirstOrDefault();

                var empSkills = db.EmployeeSkills.Where(es => es.EmployeeId == id).Join(
                    db.EmployeeSkillStates,
                    es => es.Id,
                    ess => ess.EmployeeSkillId,
                    (es, ess) => new { EmpSkill = es, ess.SkillStateId });

                employee.Skills = empSkills.Select(es => new EmployeeSkillViewModel
                {
                    Name = db.Skills.Where(s => s.Id == es.EmpSkill.SkillId).FirstOrDefault().Name,
                    Description = db.Skills.Where(s => s.Id == es.EmpSkill.SkillId).FirstOrDefault().Description,
                    State = db.SkillStates.Where(ss => ss.Id == es.SkillStateId).FirstOrDefault().Name
                }).ToList();

            }
            return employee;
        }

        public class EmployeeSkillViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string State { get; set; }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Job { get; set; }

        public List<Language> Languages { get; set; } = new List<Language>();

        public Location Location { get; set; }

        public List<EmployeeSkillViewModel> Skills { get; set; } = new List<EmployeeSkillViewModel>();
    }
}