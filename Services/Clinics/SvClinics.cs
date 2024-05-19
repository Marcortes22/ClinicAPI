using Entities;
using Microsoft.EntityFrameworkCore;
using Services.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Clinics
{
    public class SvClinics : ISvClinics
    {
        private MyContext myDbContext = default!;
        public SvClinics()
        {
            myDbContext = new MyContext();
        }
        public Clinic AddClinic(Clinic clinic)
        {
            myDbContext.clinics.Add(clinic);
            myDbContext.SaveChanges();
            return clinic;
        }

        public Clinic GetClinicBranches()
        {
            return myDbContext.clinics.Include(x => x.clinicBranch).FirstOrDefault(x => x.Id == 1);
        }

        public Clinic GetClinicUsers()
        {
            return myDbContext.clinics.Include(x => x.users).SingleOrDefault(x => x.Id == 1);

        }

        public Clinic UpdateClinic(Clinic clinic)
        {
            Clinic clinictToUpdate = myDbContext.clinics.Find(1);
            if (clinictToUpdate != null)
            {
                clinictToUpdate.Name = clinic.Name;
                clinictToUpdate.Description = clinic.Description;
                clinictToUpdate.CellPhone = clinic.CellPhone;
                clinictToUpdate.Address = clinic.Address;
                clinictToUpdate.Email = clinic.Email;
                myDbContext.clinics.Update(clinictToUpdate);
                myDbContext.SaveChanges();

            }
            return clinictToUpdate;
        }
    }
}
