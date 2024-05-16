using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services.Clinics
{
    public interface ISvClinics
    {
        public Clinic AddClinic(Clinic clinic);

        public Clinic GetClinicById(int id);

        public Clinic UpdateClinic(int id, Clinic clinic);

        public Clinic GetUsersFromClinic(int id);
    }
}
