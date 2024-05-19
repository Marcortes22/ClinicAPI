using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Roles;


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
        public IEnumerable<Role> get()
        {
            return _svRole.GetAllRoles();
        }

        [HttpPost()]
        public Role Register([FromBody] Role role)
        {
            return _svRole.addRole(role);

        }
    }
}
