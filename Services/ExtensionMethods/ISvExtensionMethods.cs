using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DTOs;

namespace Services.ExtensionMethods
{
   public  interface  ISvExtensionMethods
    {
        public User toUser(UserDto userDto);
        public ClinicBranch toClinicBranch(ClinicBrancDto clinicBrancDto);
        public Clinic toClinic(ClinicDto clinicDto);
        public Appointment toAppointment(AppointmentDto appointmentDto);
        public AppointmentType toAppointmentType(AppointmentTypeDto appointmentTypeDto);
        public Role toRole(RoleDto roleDto);

        public AppointmentDto ToAppointmentDto(Appointment appointment);
        public UserDto ToUserDto(User user);
        public ClinicBrancDto ToClinicBranchDto(ClinicBranch clinicBranch);
        public AppointmentTypeDto ToAppointmenTypetDto(AppointmentType appointmentType);
        public ClinicDto ToClinicDto(Clinic clinic);
    }
}
