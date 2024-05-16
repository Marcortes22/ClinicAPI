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

      
       
        [HttpGet("{id}/branches")]
        public Clinic Get(int id)
        {
            return _svClinic.GetClinicById(id);
        }


        [HttpGet("{id}/users")]
        [Authorize(Roles = "ADMIN")]
        public Clinic GetUsers(int id)
        {
            return _svClinic.GetUsersFromClinic(id);
        }


        [HttpPost]
       // [Authorize(Roles = "ADMIN")]
        public void Register([FromBody] Clinic clinic)
        {
            _svClinic.AddClinic(clinic);

        }


        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public void Put(int id, [FromBody] Clinic clinic)
        {
            _svClinic.UpdateClinic(id, new Clinic
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
