using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClinicBranches
{
    public interface ISvClinicBranches
    {

        public List<ClinicBranch> getAllClinicBranches();
        public ClinicBranch AddClinicBranch(ClinicBranch branch);
    }
}
