using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.UserRoles
{
    public interface ISvUserRoles

    { 
        public UserRole AddUserRole(UserRole role);

        public bool verifyAdminRole(int userId);
    }
}
