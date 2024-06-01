using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.sendMails
{
    public interface ISvEmailSender
    {
        Task SendEmail(AppointmentDto appointmentInformation);
    }
}
