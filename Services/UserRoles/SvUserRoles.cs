using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserRoles
{
    public class SvUserRoles: ISvUserRoles
    {
        private MyContext myDbContext = default!;
        public SvUserRoles()
        {
            myDbContext = new MyContext();
        }
        public List<UserRole> GetRolesByUser(int id)
        {
            return myDbContext.userRoles.Include(x => x.UserId == id).ToList();
        }


        public UserRole AddUserRole(UserRole role)
        {
            myDbContext.userRoles.Add(role);
            myDbContext.SaveChanges();
            return role;
        }

        public bool verifyAdminRole(int userId)
        {
            //UserRole dmin = myDbContext.userRoles.Include(x => x.RoleId == 1).SingleOrDefault(x=> x.UserId == userId);
            UserRole role = myDbContext.userRoles.SingleOrDefault(x => x.UserId == userId && x.RoleId == 1);
            if (role != default)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
