using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiYo.Models.Validation
{
    public class RoleValidator
    {
        public bool IsSuperAdmin(string userId)
        {
            return false;
        }

        public bool IsAdmin(string userId)
        {
            return false;
        }

        public bool IsEmpoyee(string userId)
        {
            return true;
        }

        public int? GetRoleId(string role)
        {
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.UserRoles.Where(r => String.Equals(r.Name, role)).
                    FirstOrDefault()?.Id;
            }
            return roleId;
        } 
    }
}