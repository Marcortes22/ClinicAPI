using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.AppointmentTypes
{
    internal interface ISvAppointmentType
    {
        public List<AppointmentType> getAllAppointmentTypes();

        public AppointmentType addAppointmentType(AppointmentType type);
    }
}
