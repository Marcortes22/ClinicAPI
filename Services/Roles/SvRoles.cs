using Entities;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Roles
{

    public class SvRoles : ISvRoles
    {

        private MyContext myDbContext = default!;
        public SvRoles()
        {
            myDbContext = new MyContext();
        }
        public Role addRole(Role role)
        {
             myDbContext.roles.Add(role);
            myDbContext.SaveChanges();
            return role;
        }

        public List<Role> GetAllRoles()
        {
            return myDbContext.roles.ToList();
        }
    }
}
