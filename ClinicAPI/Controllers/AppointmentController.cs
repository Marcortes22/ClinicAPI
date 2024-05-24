using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Appointments;
using Services.ClinicBranches;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class AppointmentController : ControllerBase
    {

        private  ISvAppointmet _svAppointmet;
        public AppointmentController(ISvAppointmet svAppointmet)
        {
            _svAppointmet = svAppointmet;
        }


        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _svAppointmet.getAllAppointments();
        }

        [HttpGet("id/{AppointmentId}")]
        [Authorize(Roles = "ADMIN")]
        public Appointment GetAppointmentById(int AppointmentId)
        {
            return _svAppointmet.getAppointmentById(AppointmentId);
        }

        [HttpGet("user/{UserId}")] 
        public IEnumerable<Appointment> GetAppointmentByUser(int UserId)
        {
            return _svAppointmet.getAppointmentsByUser(UserId);
        }


        [HttpPost("register")]
        public Appointment Register([FromBody] Appointment appointment)
        {
            return _svAppointmet.addAppointment(appointment);
           
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public Appointment Put([FromBody] Appointment appointment, int id)
        {
            return _svAppointmet.UpdateAppointment(new Appointment
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Time = appointment.Time,
                Status = appointment.Status,
                userId = appointment.userId,
                clinicBranchId = appointment.clinicBranchId,
                appointmentTypeId = appointment.appointmentTypeId
            },id); ;
        }

        [HttpDelete("{appointmentId}")]
        public void Cancel(int appointmentId)
        {
             _svAppointmet.DeleteAppointment(appointmentId);

        }
    }
}
