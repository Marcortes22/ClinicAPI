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

                myDbContext.appointments.Add(appointment);
                myDbContext.SaveChanges();
                return appointment;

        }


        public List<Appointment> getAllAppointments()
        {
            return myDbContext.appointments.Include(x=> x.user).Include(y=> y.appointmentType).Include(x=> x.clinicBranch).ToList();
           // return myDbContext.appointments.ToList();
             
        }

        public Appointment getAppointmentById(int appointmentId)
        {
             //return myDbContext.appointments.Find(appointmentId);
            return myDbContext.appointments.Include(x => x.user).Include(y => y.appointmentType).Include(x => x.clinicBranch).SingleOrDefault(x=>x.Id == appointmentId);
        }

        public Appointment UpdateAppointment(Appointment appointment, int appointmentId)
        {
            Appointment appointmentToUpdate = myDbContext.appointments.Find(appointmentId);

            if (appointmentToUpdate != null)
            {
                appointmentToUpdate.Date = appointment.Date;
                appointmentToUpdate.Time = appointment.Time;
                appointmentToUpdate.Status = appointment.Status;
                appointmentToUpdate.Status = appointment.Status;
                appointmentToUpdate.userId = appointment.userId;
                appointmentToUpdate.clinicBranchId = appointment.clinicBranchId;
                appointmentToUpdate.appointmentTypeId = appointment.appointmentTypeId;
                myDbContext.appointments.Update(appointmentToUpdate);
                myDbContext.SaveChanges();

            }
            return appointment;
        }


        public  List<Appointment> getAppointmentsByUser(int userId)
        {
             return myDbContext.appointments.Include(x => x.user).Include(y => y.appointmentType).Include(x => x.clinicBranch).Where(x => x.userId == userId && x.Status == true).ToList();
            //return myDbContext.appointments.Where(x => x.userId == userId).ToList();
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

        public void CancellAppointment(Appointment appointmentToCancel)
        {
            appointmentToCancel.Status = false;
            myDbContext.appointments.Update(appointmentToCancel);
            myDbContext.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointmentToDelete)
        {
          
            myDbContext.Remove(appointmentToDelete);
            myDbContext.SaveChanges();
        }
    }
}
