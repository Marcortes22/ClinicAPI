using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClinicBranch
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string CellPhone { get; set; }
     public string Address { get; set; }
     public string Email { get; set; }
     public int clinicId { get; set; }
     public Clinic? clinic { get; set; }
     public List<Appointment>? appointment { get; set; } = [];
    }   
}
