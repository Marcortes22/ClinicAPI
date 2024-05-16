using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Appointments
{
    internal interface ISvAppointmet
    {
        public List<Appointment> getAllAppointments();

        public Appointment getAppointmentById(int appointmentId);

        public Appointment getAppointmentByUser(int userId);

        public bool validateCancelAppointmet(int appointmentId);

        public bool validateAppointmetDay(DateOnly date);

        public Appointment addAppointment(Appointment appointment);

        public void DeleteAppointment(int appointmentId);


    }
}
