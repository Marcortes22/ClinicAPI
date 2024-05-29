using DTOs;
using Entities;
using Services.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExtensionMethods
{
    public class SvExtensionMethods : ISvExtensionMethods
    {

        //Methods to get entity from dto
        public Appointment toAppointment(AppointmentDto appointmentDto)
        {
            return new Appointment
            {
                Id = appointmentDto.Id,
                Date = appointmentDto.Date,
                Time = appointmentDto.Time,
                Status = appointmentDto.Status,
                userId = appointmentDto.userId,
                clinicBranchId = appointmentDto.clinicBranchId,
                appointmentTypeId = appointmentDto.appointmentTypeId
                // Asumiendo que no se necesitan conversiones para los objetos UserDto, ClinicBrancDto, y AppointmentTypeDto
            };
        }

        public AppointmentType toAppointmentType(AppointmentTypeDto appointmentTypeDto)
        {
            return new AppointmentType
            {
                Id = appointmentTypeDto.Id,
                Name = appointmentTypeDto.Name
            };
        }

        public Clinic toClinic(ClinicDto clinicDto)
        {
            return new Clinic
            {
                Id = clinicDto.Id,
                Name = clinicDto.Name,
                Description = clinicDto.Description,
                CellPhone = clinicDto.CellPhone,
                Address = clinicDto.Address,
                Email = clinicDto.Email
            };
        }

        public ClinicBranch toClinicBranch(ClinicBrancDto clinicBrancDto)
        {
            return new ClinicBranch
            {
                Id = clinicBrancDto.Id,
                Name = clinicBrancDto.Name,
                CellPhone = clinicBrancDto.CellPhone,
                Address = clinicBrancDto.Address,
                Email = clinicBrancDto.Email,
                clinicId = clinicBrancDto.clinicId
            };
        }

        public Role toRole(RoleDto roleDto)
        {
            return new Role
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
                Description = roleDto.Description
            };
        }

        public User toUser(UserDto userDto)
        {
            var user =  new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                CellPhone = userDto.CellPhone,
                UserName = userDto.UserName,
                Password = userDto.Password,
                clinicId = userDto.clinicId,
               
            };
            if(userDto.role != null)
            {
                foreach(var role in userDto.role)
                {
                    user.roles?.Add(toRole(role));
                }
            }

            return user;
        }


        //Methods to get dto from entity
        public AppointmentDto ToAppointmentDto(Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                Date = appointment.Date,
                Time = appointment.Time,
                Status = appointment.Status,
                userId = appointment.userId,
                clinicBranchId = appointment.clinicBranchId,
                appointmentTypeId = appointment.appointmentTypeId,
                user = appointment.user == null ? null : ToUserDto(appointment.user),
                clinicBranch = appointment.clinicBranch == null ? null : ToClinicBranchDto(appointment.clinicBranch),
                appointmentType = appointment.appointmentType == null ? null : ToAppointmenTypetDto(appointment.appointmentType),
            };
        }

        public UserDto ToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                CellPhone = user.CellPhone,
                UserName = user.UserName,
                Password = user.Password,
                clinicId = user.clinicId
            };
        }

        public ClinicBrancDto ToClinicBranchDto(ClinicBranch clinicBranch)
        {
            return new ClinicBrancDto
            {
                Id = clinicBranch.Id,
                Name = clinicBranch.Name,
                CellPhone = clinicBranch.CellPhone,
                Address = clinicBranch.Address,
                Email = clinicBranch.Email,
                clinicId = clinicBranch.clinicId
            };
        }

        public AppointmentTypeDto ToAppointmenTypetDto(AppointmentType appointmentType)
        {
            return new AppointmentTypeDto
            {
                Id = appointmentType.Id,
                Name = appointmentType.Name
            };
        }

        public ClinicDto ToClinicDto(Clinic clinic)
        {
            var clinicDto =  new ClinicDto
            {
                Id = clinic.Id,
                Name = clinic.Name,
                Description = clinic.Description,
                CellPhone = clinic.CellPhone,
                Address = clinic.Address,
                Email = clinic.Email,

            }; 

            if(clinic.users != null)
            {
                foreach(var user in clinic.users)
                {
                    clinicDto.users.Add(ToUserDto(user));
                }
            }

            if (clinic.clinicBranch != null)
            {
                foreach (var branch in clinic.clinicBranch)
                {
                    clinicDto.clinicBranch.Add(ToClinicBranchDto(branch));
                }
            }


            return clinicDto;
        }
    }
}
