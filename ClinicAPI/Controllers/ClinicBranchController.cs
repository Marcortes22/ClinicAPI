using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Clinics;
using Services.ClinicBranches;
using Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Authorize(Roles = "ADMIN")]
    public class ClinicBranchController : ControllerBase
    {
        private ISvClinicBranches _svClinicBranch;
        public ClinicBranchController(ISvClinicBranches svClinicBranch)
        {
            _svClinicBranch = svClinicBranch;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var branches =  _svClinicBranch.getAllClinicBranches();

            if(branches != null)
            {
                return Ok(branches);
            }
            else
            {
                return NotFound(branches);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] ClinicBranch branch)
        {
            var branchAdded =  _svClinicBranch.AddClinicBranch(branch);

            if (branchAdded != null)
            {
                return Ok(branchAdded);
            }
            else
            {
                return BadRequest("Branch was not added");
            }

        }
    }
}
