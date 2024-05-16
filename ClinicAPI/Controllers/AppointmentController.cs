using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Appointments;
using Services.ClinicBranches;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private  ISvAppointmet _svAppointmet;
        public AppointmentController(ISvAppointmet svAppointmet)
        {
            _svAppointmet = svAppointmet;
        }


        [HttpGet]
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _svAppointmet.getAllAppointments();
        }

        [HttpGet("id/{AppointmentId}")] 
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
        public void Register([FromBody] Appointment appointment)
        {
            _svAppointmet.addAppointment(appointment);
           
        }
    }
}
