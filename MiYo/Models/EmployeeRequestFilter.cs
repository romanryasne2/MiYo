using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiYo.Models
{
    public class EmployeeRequestFilter
    {
        /// <summary>
        ///     Returns list of id of employye who match defined filter
        /// </summary>
        public List<int> FilterEmployee(string[] skills,
            string locationCountry, string locationCity, string locationStreet, string locationHouse,
            string language)
        {
            
            using (var db = new ApplicationDbContext())
            {
                if (skills == null &&
                    locationCountry == null &&
                    locationCity == null &&
                    locationStreet == null &&
                    locationHouse == null &&
                    language == null)
                    return db.Employees.Select(e => e.Id).ToList();

                    //search for location. If part of location is spcecified it must match with db
                    int locationId = db.Locations.Where(loc =>
                    locationCountry != null ? locationCountry.Equals(loc.Country) : true &&
                    locationCity != null ? locationCountry.Equals(loc.City) : true &&
                    locationStreet != null ? locationCountry.Equals(loc.Street) : true &&
                    locationHouse != null ? locationCountry.Equals(loc.House) : true
                    ).FirstOrDefault()?.Id ?? -1;
                int languageId = db.Languages.Where(
                    l => l.Name.Equals(language)).FirstOrDefault()?.Id ?? -1;

                //users with selected language
                var empIdList = db.EmployeeLanguages.
                    Where(el => el.LanguageId == languageId).
                    Select(el => el.EmployeeId);


                List<int> skillIdList = skills == null ? new List<int>() :
                    db.Skills.Where(s => skills.Contains(s.Name)).Select(s => s.Id).ToList();
                //users with specified language and skill
                return empIdList.Intersect(db.EmployeeSkills.
                    Where(es => skillIdList.Contains(es.SkillId)).
                    Select(es => es.EmployeeId)).ToList();
            }
        }
    }
}