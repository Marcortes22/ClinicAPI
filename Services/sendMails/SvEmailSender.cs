using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Entities;
using DTOs;
using Services.Appointments;

namespace Services.sendMails
{
    public class SvEmailSender : ISvEmailSender
    {
        public async Task SendEmail(AppointmentDto appointmentInformation)
        {
            MailAddress addressFrom = new MailAddress("clinicapi279@gmail.com", "ClinicAPI");
            MailAddress addressTo = new MailAddress(appointmentInformation.user.Email);
            MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Subject = "Appointment have been registered";
            message.IsBodyHtml = true;
            message.Body = $"HI {appointmentInformation.user.Name}, you have a new {appointmentInformation.appointmentType.Name} appointment reserved at the next branch {appointmentInformation.clinicBranch.Name}. Your appointment schedule is: {appointmentInformation.Date} {appointmentInformation.Time}";

            using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
            {
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                // Consider using environment variables or a secure way to handle credentials
                client.Credentials = new NetworkCredential("clinicapi279@gmail.com", "pimvyarhytftjlrc");

                try
                {
                    await client.SendMailAsync(message);
                }
                catch (Exception ex)
                {
                    // Log the exception, e.g., using a logging framework like Serilog, NLog, etc.
                    Console.WriteLine($"Error sending email: {ex}");
                }
            }
        }
    }
}
