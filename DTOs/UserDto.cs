using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int clinicId { get; set; } = 1;
        public List<RoleDto>? role { get; set; }

        

    }
}
