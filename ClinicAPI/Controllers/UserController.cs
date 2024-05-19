using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Services.Users;
using Microsoft.AspNetCore.Authorization;
using Services.UserRoles;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    


    public class UserController : ControllerBase
    {
        private ISvUserRoles _svUserRole;
        private ISvUsers _svUser;
        public UserController(ISvUsers svUser, ISvUserRoles svUserRole)
        {
            _svUser = svUser;
            _svUserRole = svUserRole;
    }

        [Authorize]
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _svUser.GetAllUsers();
        }


        [HttpGet("{id}/roles")]
        [Authorize]
        [Authorize(Roles = "ADMIN")]
        public IEnumerable<User> GetRoles(int id)
        {
            return _svUser.getUserRoles(id);
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            User user = _svUser.validateUser(login.UserName, login.Password);
            if (user != null)
            {

                if (_svUserRole.verifyAdminRole(user.Id))
                {
                    var token = AuthHelperscs.GenerateJWTToken(user, "ADMIN");
                    return Ok(token);
                }
                else
                {
                    var token = AuthHelperscs.GenerateJWTToken(user, "USER");
                    return Ok(token);
                }

             
            }
            else
            {
                return Ok("Unregistered");
            }

        }


        [HttpPost("register")]
        public User Register([FromBody] User user)
        {
        _svUser.AddUser(user);
            _svUserRole.AddUserRole(new UserRole
            {
                UserId = user.Id,
                RoleId = 2
            });
            return user;

        }
        /*
        [HttpPost("AddAdminRole")]
        [Authorize]
        [Authorize(Roles = "ADMIN")]
        public void userAddAdminRole([FromBody] User user)
        {
            _svUserRole.AddUserRole(new UserRole
            {
                UserId = user.Id,
                RoleId = 1
            }) ;

        }
        */
    }
}
