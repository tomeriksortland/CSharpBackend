using System;
using System.Threading.Tasks;
using DomainModel;
using DomainServices;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DataAccess.Repository
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
