using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }
        public bool Status { get; set; }

        public int userId { get; set; }

        public int clinicBranchId { get; set; }

        public int appointmentTypeId { get; set; }

        public UserDto? user { get; set; }

        public ClinicBrancDto? clinicBranch { get; set; }

        public AppointmentTypeDto? appointmentType { get; set; }

    }
}
