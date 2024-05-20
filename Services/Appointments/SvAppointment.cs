using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System.Data.SqlTypes;
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
            if (validateAppointmetDay(appointment.Date, appointment.userId))
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
           
                Appointment appointmentToCancel = myDbContext.appointments.Find(appointmentId);

                if (appointmentToCancel != null)
                {
                    if (validateCancelAppointmet(appointmentToCancel)) {
                        appointmentToCancel.Status = false;
                        myDbContext.appointments.Update(appointmentToCancel);
                        myDbContext.SaveChanges();
                      }
                    else
                      {
                      throw new ArgumentException("Appointments just cancel 24 hours before");
                      }

                }
                else
                {
                    throw new ArgumentException("Appointment does'nt found");
                }

            
           
        }

        public List<Appointment> getAllAppointments()
        {
            //return myDbContext.appointments.Include(x=> x.user).Include(y=> y.appointmentType).Include(x=> x.clinicBranch).ToList();
            return myDbContext.appointments.ToList();
             
        }

        public Appointment getAppointmentById(int appointmentId)
        {
             return myDbContext.appointments.Find(appointmentId);
           // return myDbContext.appointments.Include(x => x.user).Include(y => y.appointmentType).Include(x => x.clinicBranch).SingleOrDefault(x=>x.Id == appointmentId);
        }

        public  List<Appointment> getAppointmentsByUser(int userId)
        {
            //  return myDbContext.appointments.Include(x => x.user).Include(y => y.appointmentType).Include(x => x.clinicBranch).Where(x => x.userId == userId).ToList();
            return myDbContext.appointments.Where(x => x.userId == userId).ToList();
        }

        public bool validateAppointmetDay(DateOnly date, int userId)
        {
            Appointment appointmentAtSameDay = myDbContext.appointments.Where(x=>x.Date == date).FirstOrDefault(x=> x.userId == userId);
            
            if (appointmentAtSameDay == null)
            {
                return true;
            }
            else
            {
                return false;
            }
      
        }

        public bool validateCancelAppointmet(Appointment appointmentToCancel)
        {

            bool canCancell = true;
          
            DateOnly todayDate = DateOnly.FromDateTime(DateTime.Now);
            TimeOnly todayTime = TimeOnly.FromDateTime(DateTime.Now);
            int daysBetween = (int)(appointmentToCancel.Date.DayNumber - todayDate.DayNumber);

            if (daysBetween == 0)
            {
                canCancell = false;

            }else if (daysBetween == 1)
            {

                TimeSpan differenceTimes = appointmentToCancel.Time - todayTime;
                double hoursBetween = differenceTimes.TotalHours;

                if (hoursBetween <= 24)
                {
                    canCancell =  false;
                }

            }else if (daysBetween < 0 )
            {
                canCancell = false;
            }
         

            return canCancell;
        }
    }
}
