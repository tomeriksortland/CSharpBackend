using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Model;
using Core.Domain.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.DataAccess.Repository
{
    public class EmailService : IEmailService
    {
        public async Task<bool> Send(Email email)
        {

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email.From);
            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var plainTextContent = "Email subscription";
            var htmlContent = email.Text;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return true;
        }
    }
}
