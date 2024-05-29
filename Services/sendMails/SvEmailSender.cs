using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Entities;
using DTOs;

namespace Services.sendMails
{
    public class SvEmailSender : ISvEmailSender
    {
        public void SendEmail(AppointmentDto appointmentInformation)
        {
            
            MailAddress addressFrom = new MailAddress("clinicapi279@gmail.com", "ClinicAPI");
            MailAddress addressTo = new MailAddress(appointmentInformation.user.Email);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = "Appointment have been registered";
            message.IsBodyHtml = true;
            message.Body  = $"HI  {appointmentInformation.user.Name} you have reserved new {appointmentInformation.appointmentType.Name} Appointment. Your appointment schedule is: {appointmentInformation.Date} {appointmentInformation.Time}";
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("clinicapi279@gmail.com", "pimvyarhytftjlrc");
            try
            {
                client.Send(message);

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}