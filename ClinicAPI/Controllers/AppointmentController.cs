using Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Appointments;
using Services.sendMails;
using Services.Users;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    
    public class AppointmentController : ControllerBase
    {

        private  ISvAppointmet _svAppointmet;
        private  ISvUsers _svUser;
        private  ISvEmailSender _svEmail;
        public AppointmentController(ISvAppointmet svAppointmet, ISvUsers svUser,ISvEmailSender svEmail)
        {
            _svAppointmet = svAppointmet;
            _svEmail = svEmail;
             _svUser = svUser;

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
        public Appointment Post([FromBody] Appointment appointment)
        {
            Appointment appointmentCreated =  _svAppointmet.addAppointment(appointment);
            User userToConfirm = _svUser.GetUserById(appointmentCreated.userId);
     
            _svEmail.SendEmail( userToConfirm, appointmentCreated);
            return appointmentCreated;
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
