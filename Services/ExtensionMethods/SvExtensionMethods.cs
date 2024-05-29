using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExtensionMethods
{
    public class SvExtensionMethods : ISvExtensionMethods
    {
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
                user = new UserDto
                {
                    Id = appointment.user.Id,
                    Name = appointment.user.Name,
                    Email = appointment.user.Email,
                    CellPhone = appointment.user.CellPhone,
                    UserName = appointment.user.UserName,
                    Password = appointment.user.Password,
                    clinicId = appointment.user.clinicId
                },
                clinicBranch = new ClinicBrancDto
                {
                    Id = appointment.clinicBranch.Id,
                    Name = appointment.clinicBranch.Name,
                    CellPhone = appointment.clinicBranch.CellPhone,
                    Address = appointment.clinicBranch.Address,
                    Email = appointment.clinicBranch.Email,
                    clinicId = appointment.clinicBranch.clinicId
                },
                appointmentType = new AppointmentTypeDto
                {
                    Id = appointment.appointmentType.Id,
                    Name = appointment.appointmentType.Name
                }
            };
        }
    }
}
