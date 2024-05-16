using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.AppointmentTypes;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointTypeController : ControllerBase
    {
        private ISvAppointmentType _svAppointmetType;
        public AppointTypeController(ISvAppointmentType svAppointmetType)
        {
            _svAppointmetType = svAppointmetType;
        }

        [HttpGet]
        public IEnumerable<AppointmentType> Get()
        {
            return _svAppointmetType.getAllAppointmentTypes();
        }

        [HttpPost]
        public void AddAppointment([FromBody] AppointmentType type)
        {
            _svAppointmetType.addAppointmentType(type);

        }
    }
}
