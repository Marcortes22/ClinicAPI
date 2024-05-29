using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Users;
using Services.Clinics;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Services.ExtensionMethods;
using DTOs;
namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicController : ControllerBase
    {

        private ISvClinics _svClinic;
        private ISvExtensionMethods _extensionMethods;
        public ClinicController(ISvClinics svClinic, ISvExtensionMethods extensionMethods)
        {
            _svClinic = svClinic;
            _extensionMethods = extensionMethods;
        }

      
       
        [HttpGet("branches")]
        public IActionResult GetClinicBranches()
        {
            var clinicWithBranches =  _svClinic.GetClinicBranches();
            

            if (clinicWithBranches != null)
            {
                var clinicDto = _extensionMethods.ToClinicDto(clinicWithBranches);

                return Ok(clinicDto);

            }
            else
            {
                return BadRequest("There are not clinic branches yet");
            }
        }


        [HttpGet("users")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetClinicUsers()
        {
            var clinicWithUsers = _svClinic.GetClinicUsers();


            if (clinicWithUsers != null)
            {
                var clinicDto = _extensionMethods.ToClinicDto(clinicWithUsers);

                return Ok(clinicDto);

            }
            else
            {
                return BadRequest("There are not users at the clinic yet");
            }
        }


        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Post([FromBody] ClinicDto clinic)
        {
            var clinicToCreate = _svClinic.AddClinic(_extensionMethods.toClinic(clinic));

            if (clinicToCreate != null)
            {
                return Ok(clinicToCreate);
            }
            else
            {
                return BadRequest("Clinic was not created");
            }

        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Put( [FromBody] ClinicDto clinic)
        {
            var newClinicInformation = _extensionMethods.toClinic(clinic);

            var clinicUpdated = _svClinic.UpdateClinic(newClinicInformation);

            if (clinicUpdated != null)
            {
                return Ok(clinicUpdated);
            }
            else
            {
                return BadRequest("Clinic was not updated");
            }
            
        }

    }
}
