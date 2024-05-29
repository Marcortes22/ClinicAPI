using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Roles
{
    public interface ISvRoles
    {
        public List<Role> GetAllRoles();

        public Role addRole(Role role);

        public Role getRoleByName(string name);
    }
}
