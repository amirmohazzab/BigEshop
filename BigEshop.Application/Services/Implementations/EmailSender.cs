using BigEshop.Application.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
	public class EmailSender (ILogger<EmailSender> logger) : IEmailSender
	{
        public Task<bool> Send(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public bool SendEmail(string to, string subject, string body)
		{
            try
            {
                string appPassword = "sdzm ogjf nphs xwtd";
                string fromEmail = "aspadvancedcourse@gmail.com";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail, "کمپ آموزشی پیشرفته ASP");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = true;

                SmtpServer.UseDefaultCredentials = false;

                SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, appPassword);
                SmtpServer.Send(mail);

                return true;
            }
            catch (Exception exception)
            {
                logger.LogError($"Email Error\n\tErrorMessage:: {exception.Message}");
                return false;
            }
        }
	}
}
