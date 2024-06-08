using DTOs;
using Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Appointments;
using Services.ExtensionMethods;
using Services.sendMails;
using Services.Users;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    
    public class AppointmentController : ControllerBase
    {

        private  ISvAppointmet _svAppointmet;
        private  ISvEmailSender _svEmail;
        private ISvExtensionMethods _extensionMethods;
        public AppointmentController(ISvAppointmet svAppointmet, ISvExtensionMethods extensionMethods,ISvEmailSender svEmail)
        {
            _svAppointmet = svAppointmet;
            _svEmail = svEmail;
            _extensionMethods = extensionMethods;

        }


        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAllAppointments()
        {
            var appointments = _svAppointmet.getAllAppointments();
            List<AppointmentDto> appointmentDtoList = new List<AppointmentDto>();

            if (appointments != null)
            {

                foreach (var appointment in appointments)
                {
                    appointmentDtoList.Add(_extensionMethods.ToAppointmentDto(appointment));
                }

                return Ok(appointmentDtoList);
            }
            else
            {
                return BadRequest("There are not appointments yet");
            }
            
        }

        [HttpGet("today")]
       // [Authorize(Roles = "ADMIN")]
        public IActionResult GetTodayAppointments()
        {
            var appointments = _svAppointmet.getAllAppointments();
            List<AppointmentDto> appointmentDtoList = new List<AppointmentDto>();

            if (appointments != null)
            {

                foreach (var appointment in appointments)
                {
                    appointmentDtoList.Add(_extensionMethods.ToAppointmentDto(appointment));
                }

                return Ok(appointmentDtoList);
            }
            else
            {
                return BadRequest("There are not appointments yet");
            }

        }

        [HttpGet("id/{AppointmentId}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetAppointmentById(int AppointmentId)
        {
            var appointmentSearched = _svAppointmet.getAppointmentById(AppointmentId);

            if (appointmentSearched != null)
            {
                return Ok(_extensionMethods.ToAppointmentDto(appointmentSearched));
            }
            else
            {
                return BadRequest("Appointment was not found");
            }
         
        }

        [HttpGet("user/{UserId}")] 
        public IActionResult GetAppointmentByUser(int UserId)
        {
           var appointments =  _svAppointmet.getAppointmentsByUser(UserId);
           List<AppointmentDto> appointmentDtoList = new List<AppointmentDto>();

            if (appointments != null)
            {

                foreach (var appointment in appointments)
                {
                    appointmentDtoList.Add(_extensionMethods.ToAppointmentDto(appointment));
                }

                return Ok(appointmentDtoList);
            }
            else
            {
                return BadRequest(new {message = "This user does not have appointments yet"});
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] Appointment appointment)
        {
            if (_svAppointmet.validateAppointmetDay(appointment.Date, appointment.userId))
            {
                var appointmentToCreate = _svAppointmet.addAppointment(appointment);
                if (appointmentToCreate != null)
                {
                    AppointmentDto appointmentInformation = _extensionMethods.ToAppointmentDto(_svAppointmet.getAppointmentById(appointmentToCreate.Id));
                    _svEmail.SendEmail(appointmentInformation); // Llamada asíncrona
                    return Ok(appointmentToCreate);
                }
                else
                {
                    return BadRequest(new { message = "Appointment was not created" });
                }
            }
            else
            {
                return BadRequest(new { message = "You can't get two appointments on the same day" });
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Put([FromBody] Appointment appointment, int id)
        {
            Appointment appointmentToUpdate = _svAppointmet.getAppointmentById(appointment.Id);

            if (appointmentToUpdate != null)
            {
                var appointmentUpdated = _svAppointmet.UpdateAppointment(new Appointment
                {
                    Id = appointment.Id,
                    Date = appointment.Date,
                    Time = appointment.Time,
                    Status = appointment.Status,
                    userId = appointment.userId,
                    clinicBranchId = appointment.clinicBranchId,
                    appointmentTypeId = appointment.appointmentTypeId
                }, id); ;

                if (appointmentToUpdate != null)
                {
                    return Ok(appointmentUpdated);
                }
                else
                {
                    return BadRequest(new { message = "Appointment was not updated" });
                }
            }
            else
            {
                return BadRequest("Appointment to update did not found");
            }
           
        }

        [HttpDelete("cancell/{appointmentId}")]
        public IActionResult Cancel(int appointmentId)
        {
            var appointmentToCancel = _svAppointmet.getAppointmentById(appointmentId);

            if (appointmentToCancel != null)
            {

                bool canCancelAppointment = _svAppointmet.validateCancelAppointmet(appointmentToCancel);

                if (canCancelAppointment)
                {
                    _svAppointmet.CancellAppointment(appointmentToCancel);

                    return Ok("Appointment canceled");
                }
                else
                {
                    return BadRequest(new { message = "Appointments just cancel 24 hours before" });
                }

            }
            else
            {
                return NotFound(new { message = "Appointment to cancel did not found" });
            }
           

        }

        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{appointmentId}")]
        public IActionResult Delete(int appointmentId)
        {

            var appointmentToDelete = _svAppointmet.getAppointmentById(appointmentId);

            if (appointmentToDelete != null)
            {

               _svAppointmet.DeleteAppointment(appointmentToDelete);
                return Ok(new { message = "Appointment have been deleted" });

            }
            else
            {
                return NotFound(new { message = "Appointment to delete did not found" });
            }


        }
    }
}
