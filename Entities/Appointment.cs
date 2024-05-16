using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Appointment { 
    
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }
        public bool Status { get; set; }

        public int userId { get; set; }
        public User? user { get; set; }

        public int clinicBranchId { get; set; }
        public ClinicBranch? clinicBranch { get; set; }

        public int appointmentId { get; set; }
        public AppointmentType? appointmentType { get; set; }


    }
}
