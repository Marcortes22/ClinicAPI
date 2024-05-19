using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Services.Clinics;
using Entities;
using Microsoft.AspNetCore.Authorization;
namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClinicController : ControllerBase
    {

        private ISvClinics _svClinic;
        public ClinicController(ISvClinics svClinic)
        {
            _svClinic = svClinic;
        }

      
       
        [HttpGet("branches")]
        public Clinic Get()
        {
            return _svClinic.GetClinicBranches();
        }


        [HttpGet("users")]
        [Authorize(Roles = "ADMIN")]
        public Clinic GetUsers()
        {
            return _svClinic.GetClinicUsers();
        }


        [HttpPost]
       // [Authorize(Roles = "ADMIN")]
        public Clinic Register([FromBody] Clinic clinic)
        {
            return _svClinic.AddClinic(clinic);

        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public Clinic Put( [FromBody] Clinic clinic)
        {
           return _svClinic.UpdateClinic( new Clinic
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Description = clinic.Description,
                CellPhone = clinic.CellPhone,
                Address = clinic.Address,
                Email = clinic.Email
            });
        }

    }
}
