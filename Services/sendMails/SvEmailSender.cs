using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Entities;

namespace Services.sendMails
{
    public class SvEmailSender : ISvEmailSender
    {
        public void SendEmail( User userTo, Appointment appointment)
        {
            // Set up SMTP client
            MailAddress addressFrom = new MailAddress("clinicapi279@gmail.com", "ClinicAPI");
            MailAddress addressTo = new MailAddress(userTo.Email);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = "Appointment have been registered";
            message.IsBodyHtml = true;
            message.Body  = $"HI  {userTo.Name} \nAppointment information: {appointment.Date} {appointment.Time}";
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