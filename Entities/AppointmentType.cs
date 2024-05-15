using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int appointmentId { get; set; }

        public Appointment appointment { get; set; }
    }
}
