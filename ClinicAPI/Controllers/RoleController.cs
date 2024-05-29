using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Roles;
using System.Data;


namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    //[Authorize(Roles = "ADMIN")]
    public class RoleController : ControllerBase
    {

        private ISvRoles _svRole;
        public RoleController(ISvRoles svRole)
        {
            _svRole = svRole;
        }

        [HttpGet]
        public IActionResult get()
        {
            var roles =  _svRole.GetAllRoles();

            if(roles != null)
            {
                return Ok(roles);
            }
            else
            {
                return BadRequest("There are not roles yet");
            }
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Role role)
        {
            var newRole = _svRole.addRole(role);

            if (newRole != null)
            {
                return Ok(newRole);
            }
            else
            {
                return BadRequest("Role was not added");
            }


        }
    }
}
