using DTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AppointmentTypes;
using Services.ExtensionMethods;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointTypeController : ControllerBase
    {
        private ISvAppointmentType _svAppointmetType;
        private ISvExtensionMethods _extensionMethods;

        public AppointTypeController(ISvAppointmentType svAppointmetType, ISvExtensionMethods extensionMethods)
        {
            _svAppointmetType = svAppointmetType;
            _extensionMethods = extensionMethods;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var appointmentTypes = _svAppointmetType.getAllAppointmentTypes();
           

            if (appointmentTypes != null)
            {
                List<AppointmentTypeDto> appointmentTypeDto = new List<AppointmentTypeDto>();

                foreach (var appointmentType in appointmentTypes)
                {
                    appointmentTypeDto.Add(_extensionMethods.ToAppointmenTypetDto(appointmentType));
                }

                return Ok(appointmentTypeDto);
            }
            else
            {
              return  NotFound("There are not appointmets types yet");
            }
        }

        [HttpPost]
        public IActionResult AddAppointment([FromBody] AppointmentType type)
        {
            var typeAdded =  _svAppointmetType.addAppointmentType(type);

            if(typeAdded != null)
            {
                return Ok(typeAdded);
            }
            else
            {
                return BadRequest("Appointment type was not added");
            }

        }
    }
}
