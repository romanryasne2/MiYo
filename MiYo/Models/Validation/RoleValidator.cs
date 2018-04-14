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
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id == userId).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == GetRoleId("SuperAdmin");
        }

        public bool IsAdmin(string userId)
        {
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id == userId).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == GetRoleId("Admin");
        }

        public bool IsEmpoyee(string userId)
        {
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id == userId).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == GetRoleId("Employee");
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