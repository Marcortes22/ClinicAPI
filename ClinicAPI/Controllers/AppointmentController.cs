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
    [Authorize]
    
    public class AppointmentController : ControllerBase
    {

        private  ISvAppointmet _svAppointmet;
        private  ISvUsers _svUser;
        private  ISvEmailSender _svEmail;
        private ISvExtensionMethods _extensionMethods;
        public AppointmentController(ISvAppointmet svAppointmet, ISvExtensionMethods extensionMethods, ISvUsers svUser,ISvEmailSender svEmail)
        {
            _svAppointmet = svAppointmet;
            _svEmail = svEmail;
             _svUser = svUser;
            _extensionMethods = extensionMethods;

        }


    [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _svAppointmet.getAllAppointments();
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
                return BadRequest("This user does not have appointments yet");
            }
        }


        [HttpPost("register")]
        public IActionResult Post([FromBody] Appointment appointment)
        {
            if (_svAppointmet.validateAppointmetDay(appointment.Date, appointment.userId))
            {
                var appointmentToCreate = _svAppointmet.addAppointment(appointment);
                if (appointmentToCreate != null)
                {
                // User userToConfirm = _svUser.GetUserById(appointmentToCreate.userId);
                  AppointmentDto appointmentInformation = _extensionMethods.ToAppointmentDto(_svAppointmet.getAppointmentById(appointmentToCreate.Id));
                 _svEmail.SendEmail(appointmentInformation); //enviar tambien el appointment type
                  return Ok(appointmentInformation);
                }
                else
                {
                    return BadRequest("Appointment was not created");
                }

            }
            else
            {
                return BadRequest("You cant get two appointments at the same day");
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
                    return BadRequest("Appointment was not updated");
                }
            }
            else
            {
                return BadRequest("Appointment to update did not found");
            }
           
        }

        [HttpDelete("{appointmentId}")]
        public IActionResult Cancel(int appointmentId)
        {
            var appointmentToCancel = _svAppointmet.getAppointmentById(appointmentId);

            if (appointmentToCancel != null)
            {

                bool canCancelAppointment = _svAppointmet.validateCancelAppointmet(appointmentToCancel);

                if (canCancelAppointment)
                {
                    _svAppointmet.DeleteAppointment(appointmentToCancel);

                    return Ok("Appointment canceled");
                }
                else
                {
                    return BadRequest("Appointments just cancel 24 hours before");
                }

            }
            else
            {
                return NotFound("Appointment to cancel did not found");
            }
           

        }
    }
}
