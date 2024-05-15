using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Clinic
    {

     public int Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public string CellPhone { get; set; }
     public string Address { get; set; }
     public string Email { get; set; }

     public List<ClinicBranch> clinicBranch { get; set; } = [];

        public List<User> users { get; set; } = [];

    }
}
