using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Appointments;
using Services.ClinicBranches;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
   // [Authorize]
    
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
    }
}
