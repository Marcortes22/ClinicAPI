using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DTOs;
using Services.Users;
using Microsoft.AspNetCore.Authorization;
using Services.UserRoles;
using Services.Roles;
using Services.ExtensionMethods;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    


    public class UserController : ControllerBase
    {
        private ISvUserRoles _svUserRole;
        private ISvRoles _svRoles;
        private ISvUsers _svUser;
        private ISvExtensionMethods _extensionMethods;
        public UserController(ISvUsers svUser, ISvUserRoles svUserRole, ISvExtensionMethods extensionMethods, ISvRoles svRoles)
        {
            _svUser = svUser;
            _svUserRole = svUserRole;
            _extensionMethods = extensionMethods;
            _svRoles = svRoles;
        }

        [Authorize]
        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_svUser.GetAllUsers());
        }


        [HttpGet("{id}/roles")]
        [Authorize]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetRoles(int id)
        {
            var userRoles = _svUser.getUserRoles(id);

            if(userRoles == null)
            {
                return BadRequest("User not found");
            }

            return Ok(userRoles);
           
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
                    var tokenObject = new { access_token = token };

                    return Ok(tokenObject);
                }
                else
                {
                    var token = AuthHelperscs.GenerateJWTToken(user, "USER");
                    var tokenObject = new { access_token = token };
                    return Ok(tokenObject);
                }

             
            }
            else
            {
                return Unauthorized("Unregistered");
            }

        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            User newUser = _extensionMethods.toUser(userDto);
            User UserAdded = _svUser.AddUser(newUser);
            Role defaultRole = _svRoles.getRoleByName("USER");

            if (UserAdded != null)
            {
                _svUserRole.AddUserRole(new UserRole
                {
                    UserId = UserAdded.Id,
                    RoleId = defaultRole.Id
                })  ;
               return Ok(UserAdded);
            }
            else
            {
               return BadRequest("User can't be added");
            }

        }

        //[HttpPost("AddAdminRole")]
        //[Authorize]
        //[Authorize(Roles = "ADMIN")]
        //public void userAddAdminRole([FromBody] User user)
        //{
        //    _svUserRole.AddUserRole(new UserRole
        //    {
        //        UserId = user.Id,
        //        RoleId = 1
        //    });

        //}

    }
}
