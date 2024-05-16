using Entities;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ClinicBranches
{
    public class SvClinicBranches : ISvClinicBranches
    {
        private MyContext myDbContext = default!;
        public SvClinicBranches()
        {
            myDbContext = new MyContext();
        }
        public ClinicBranch AddClinicBranch(ClinicBranch branch)
        {

          myDbContext.clinicBranches.Add(branch);
          myDbContext.SaveChanges();
            return branch;
            
        }

        public List<ClinicBranch> getAllClinicBranches()
        {
            return myDbContext.clinicBranches.ToList();
        }
    }
}
