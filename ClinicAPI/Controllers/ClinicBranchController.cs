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
   // [Authorize]
   // [Authorize(Roles = "ADMIN")]
    public class ClinicBranchController : ControllerBase
    {
        private ISvClinicBranches _svClinicBranch;
        public ClinicBranchController(ISvClinicBranches svClinicBranch)
        {
            _svClinicBranch = svClinicBranch;
        }

        [HttpGet]
        public List<ClinicBranch> Get()
        {
            return _svClinicBranch.getAllClinicBranches();
        }


        [HttpPost]
        public void Register([FromBody] ClinicBranch branch)
        {
            _svClinicBranch.AddClinicBranch(branch);

        }
    }
}
