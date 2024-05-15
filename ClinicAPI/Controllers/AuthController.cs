using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            if (true)
            {

                var token = AuthHelperscs.GenerateJWTToken(user);
                return Ok(token);
            }
            else
            {
                return Ok("NO PERMITIDO  ");
            }

        }
    }
}
