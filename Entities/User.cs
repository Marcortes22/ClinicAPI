using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{


    public class User
    {
     [DatabaseGenerated(DatabaseGeneratedOption.None)]
     public int Id { get; set; }
     public string Name { get; set;}
     public string Email { get; set;}
     public string CellPhone { get; set;}
     public string UserName{get; set;}
     public string Password{ get; set; }
     public int clinicId { get; set; } = 0;
     public Clinic? clinic { get; set; }
     public List<Appointment>? appointment { get; set;} = [];

     public List<Role>? roles { get; set;} = [];

    
     
    }
}
