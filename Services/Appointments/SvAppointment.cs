using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Appointments
{
    public class SvAppointment : ISvAppointmet
    {

        private MyContext myDbContext = default!;
        public SvAppointment()
        {
            myDbContext = new MyContext();
        }
        public Appointment addAppointment(Appointment appointment)
        {
            if (validateAppointmetDay(appointment.Date))
            {

                myDbContext.appointments.Add(appointment);
                myDbContext.SaveChanges();
                return appointment;
            }
            else
            {
                throw new ArgumentException("Cant have twice appointments at the same day");
            }


        }

        public void DeleteAppointment(int appointmentId)
        {
            if (validateCancelAppointmet(appointmentId))
            {
                Appointment appointmentToCancel = myDbContext.appointments.Find(appointmentId);

                if (appointmentToCancel != null)
                {
                    appointmentToCancel.Status = false;
                    myDbContext.appointments.Update(appointmentToCancel);
                    myDbContext.SaveChanges();

                }
                else
                {
                    throw new ArgumentException("Appointment does'nt found");
                }

            }
            else
            {
                throw new ArgumentException("Appointments just cancel 24 hours before");
            }
        }

        public List<Appointment> getAllAppointments()
        {
            return myDbContext.appointments.Include(x=> x.user).ToList();
        }

        public Appointment getAppointmentById(int appointmentId)
        {
            return myDbContext.appointments.Find(appointmentId);
        }

        public  List<Appointment> getAppointmentsByUser(int userId)
        {
            return myDbContext.appointments.Include(x=> x.user).Where(x => x.userId == userId).ToList();
        }

        public bool validateAppointmetDay(DateOnly date)
        {
            return true;
        }

        public bool validateCancelAppointmet(int appointmentId)
        {
            return true;
        }
    }
}
