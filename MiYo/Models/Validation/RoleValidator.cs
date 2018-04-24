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
            if (string.IsNullOrEmpty(userId))
                return false;
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id == userId).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == 3;
        }

        public bool IsAdmin(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id.Equals(userId)).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == 2;
        }

        public bool IsEmpoyee(string userId)
        {
            int? roleId = null;
            using (var db = new ApplicationDbContext())
            {
                roleId = db.Users.Where(u => u.Id == userId).
                    FirstOrDefault()?.RoleId;
            }
            return roleId == 1;
        }

        public int? GetRoleId(string role)
        {
            if (string.IsNullOrEmpty(role))
                return null;
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