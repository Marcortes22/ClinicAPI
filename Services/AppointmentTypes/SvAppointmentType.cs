using Entities;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AppointmentTypes
{
    public class SvAppointmentType : ISvAppointmentType
    {
        private MyContext myDbContext = default!;
        public SvAppointmentType()
        {
            myDbContext = new MyContext();
        }
        public AppointmentType addAppointmentType(AppointmentType type)
        {
            myDbContext.appointmentTypes.Add(type);
            myDbContext.SaveChanges();
            return type;
        }

        public List<AppointmentType> getAllAppointmentTypes()
        {
            return myDbContext.appointmentTypes.ToList();
        }
    }
}
